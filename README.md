# CSharp-ReadFile
This is a console application that accepts a file name and prints out the key-value data in the file. The application currently supports the `.csv`,'.json' and '.xml' file extension.

### 1. Display (Print Data of various file extensions)
Output
```
Key:aaaaa Value:bbbbb
Key:ccccc Value:ddddd
Key:eeeee Value:fffff
```
  
### 2. Search (Print Data of various file extensions)
1. Prompt the user to input the search term for the key value.
2. The search term must match the key value, but the search should be case-insensitive.
3. Search the data files in the `/data` directory of this repository.
4. Print the key-value data along with the file path(s) of the data file(s) that contains the key value.
5. E.g. Given the search term to search the key value is "aAaAa", the expected result is
```
Key:aaaaa Value:bbbbb FileName:data\data.csv 
Key:aaaaa Value:bbbbb FileName:data\data2\data2.csv
```
  
