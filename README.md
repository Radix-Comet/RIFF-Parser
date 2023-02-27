# RIFF-Parser
A simple RIFF parser for C# with support for RIFF and RIFX formatting.

### What is RIFF?
RIFF is a generic file container used for storing data in chunks. With support for little-endian byte formatting (RIFF) and big-endian byte formatting (RIFX). While only ``RIFF``/``RIFX`` and ``LIST`` chunks may contain children, the format supports custom data chunks with assigned 4-byte character codes.

## Current Tasks
- [X] Reading/Writing RIFF/RIFX Files
- [ ] Support for custom ``IDataChunk`` types

## Requirements
 - .NET Core 6 (or higher)
 - Visual Studio 2022
 
 
 ## Resources used:
 [RIFF File Format](http://www.daubnet.com/en/file-format-riff#:~:text=%27RIFX%27%20specifies%20%27Motorola%27,the%20file%20in%20its%20Data)
