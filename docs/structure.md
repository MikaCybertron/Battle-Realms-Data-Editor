# Structure of the H2O File Format

H2O files are broken down into six sections:
* header
* file entries
* folder names
* file names
* folder structure
* data

# Header

The header stores the general archive information. Such as total compressed archive size, and
number of files archived.

| Type   | Bytes | Name           | Description                                  |
| ------ | ----- | -------------- | -------------------------------------------- |
| char   | 8     | magicNumber    | Format identifier. Always `LIQDLH2O`         |
| float  | 4     | version1       | Always 6.0                                   |
| char   | x     | comments       | User comment section. Terminated with `0x1A` |
| uint32 | 4     | version2       | Always 6                                     |
| int32  | 4     | fileCount      | Number of files int the archive              |
| ulong  | 8     | compressedSize | Compressed size of archive in bytes          |
| ulong  | 8     | rawSize        | Uncompressed size of archive in bytes        |

## File Entries

The file entries is a sequence of the following structure repeated by `header.fileCount`. Each file
entry stores specific information about each archived file.

| Type   | Bytes | Name            | Description                                                                                                  |
| ------ | ----- | --------------- | ------------------------------------------------------------------------------------------------------------ |
| uint32 | 4     | compressionTag  | Indicates whether data for this file has been compressed or not. 0 = not compressed, 1 = compressed          |
| int32  | 4     | folderNameIndex | Array index of the folder this file resides in                                                               |
| int32  | 4     | fileNameIndex   | Array index of the name of this file                                                                         |
| int32  | 4     | fileId          | ID of the file. Always starts at 0 and increments from there                                                 |
| uint32 | 4     | rawSize         | Uncompressed size in bytes                                                                                   |
| uint32 | 4     | compressedSize  | Compressed size in bytes                                                                                     |
| ulong  | 8     | offset          | Start location of the data for this file. This is always from the start of the archive. So a value of 3340 would mean the data starts from byte 3340 of the archive |
| int32  | 4     | checksum        | CRC32 checksum                                                                                               |
| int32  | 4     | unknownField    | Unknown field. This is typically the same value for every file entry the archive, but varies across archives |

Not every entry will be a file currently in use. This will be indicated by `folderNameIndex` and
`fileNameIndex` being -1, both size fields being 0, and the checksum set to 0.

## Folder Names

This is simply an array of strings. It is usually compressed, as such it starts with a 12 byte structure
that you will see repeated for every section with data that could be compressed:

| Type   | Bytes | Name           | Description                                    |
| ------ | ----- | -------------- | ---------------------------------------------- |
| int32  | 4     | compressedSize | Compressed size of the following data in bytes |
| int32  | 4     | rawSize        | Size of the data once decompressed in bytes    |
| int32  | 4     | checksum       | CRC32 checksum                                 |

This is then followed by the array of strings.

If 'compressedSize' and 'rawSize' are different, then the following data is compressed. The data will be
compressed with [PKWARE DCL](http://fileformats.archiveteam.org/wiki/PKWARE_DCL_Implode), as indicated by
the header `00 04`.

If 'compressedSize' and 'rawSize' are the same, then the data is not compressed.

Either way, the data is structured the same:

| Type                          | Bytes | Name  | Description                                                                              |
| ----------------------------- | ----- | ----- | ---------------------------------------------------------------------------------------- |
| int32                         | 4     | count | Number of names in the array                                                             |
| int32                         | 4     | size  | Size of the data in bytes. Includes `count` and itself, so will always be a minimum of 8 |
| String (UTF-16 little endian) | x     | names | Array of strings deliminated by `0x00`. Each character is 2 bytes                        |

If no folders have been archived, then this section can be empty.

## File Names

Exactly the same as `folderNames`, excepting that it's the file names being stored here, not the folder names.

## Folder Structure

This is an array of integers storing the parent index for the folder in the same position as the `folderNames`
array above. So for example, if four folders are stored in this archive, then `folderNames` will contain:

    Example Folder
    Example Folder\\Child 1
    Example Folder\\Child 2
    Example Folder\\Child 2\\Grand Child

Then this section will have:

    -1
    0
    0
    2

`Example Folder` is the top level folder in this hierarchy, so it has no parents. As such its parent index is -1,
which is always used to indicate no parentage. `Example Folder\\Child 1` and `Example Folder\\Child 2` are
children of `Example Folder`, so their parent indexes are 0 because `Example Folder` is at position 0 in `folderNames`.
Finally we have `Example Folder\\Child 2\\Grand Child`, which is a child of `Child 2` which is at position 2.

You will also note that each folder name will contain the full path of their parentage, which renders this
section a little redundent. However, it could be used to help verify that the structure is correct.

| Type  | Bytes | Name        | Description                          |
| ----- | ----- | ----------- | ------------------------------------ |
| int32 | 4     | count       | Number of parentIndexes in the array |
| int32 | 4     | parentIndex | Parent indexes                       |

## Data

Contents of the files. The `offset` of each `fileEntry` indicates how deep into this section the contents of
that file starts.

If `fileEntry.compressionTag` is 0, then the data is not compressed and can be read straight away. `fileEntry.rawSize`
indicates the number of bytes to read.

If `fileEntry.compressionTag` is 1, then the data is compressed and must first be decompressed. The data
will be preceded by the 12 byte compression header:

| Type   | Bytes | Name           | Description                                    |
| ------ | ----- | -------------- | ---------------------------------------------- |
| int32  | 4     | compressedSize | Compressed size of the following data in bytes |
| int32  | 4     | rawSize        | Size of the data once decompressed in bytes    |
| int32  | 4     | checksum       | CRC32 checksum                                 |

While the data will be compressed by PKWARE DCL and the expected header of `00 04`.
