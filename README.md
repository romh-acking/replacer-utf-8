[//]: <> (This readme is in the markdown format. Please preview in a markdown parser.)

# Replacer (UTF-8) 

## About
This is a simple C# app to find and repalce strings based off parameters specified within a file.

## Arguments
* Argument #1: Path of find/replace file.
    * The format is `findString::replaceString` and each entry is seperate by a linebreak.
    * You can have comments. Basically any line without `::` is ignored.
* Argument #2: Directory to replace contents of txt files or single txt file.
