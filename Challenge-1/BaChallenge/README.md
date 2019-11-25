# This is a solution for BA-Challenge 2019 part 1

Done by Viktorija Kondratjevaite during 11.22 - 11.26 and will not be improved until the deadline due to a personal vacation. 🏖️

## Review of the project 🔥

This project implements such features:

- Code comments of type `//` and `/**/` are detected in any text file and the rest of file content is removed and printed into a new file.
- In short, this application finds and prints comments from any text file.
- Application is tested with different types of comments (there are quite a few edge cases to take into account)

## Things to improve ⚙️

- Hard-coded Path values should be removed and be more dynamical. Methods like `Path.GetDirectoryName()` and such should be implemented.
- Add Exception management. For example, if file content is corrupted or inputs are empty.
- If file text content is literally just text string `File does not exist`, application will think that the file is empty. This can be improved with better error management.
-

## Regex explanation 😊

Created a Regular Expression to find comments in text files `(\/\/(.[^""""]*?)\r?\n)|(^\/\/.*?$|\/\*.*?\*\/)`

- `\/\/` matches `//` (escaped characters)
- `(.[^""""]*?)\r?\n)`- group of tokens which ignores `" "` symbols, then matches either `\r` or `\n` symbols.
- `|` Alteration - boolean OR
- `(^\/\/.*?$|\/\*.*?\*\/)` - matches `/**/` types of comments
- Deep testing can be found in `CommentPrinterTests.cs` class.
