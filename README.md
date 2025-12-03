Requirements
------------
- install .NET 8.0 Runtime

Usage
-----
1. Open command prompt
2. Navigate to where you saved the program
3. Type the command with image path

Example:
	C:\user\Toyota\BlackLineCountChecker\bin\Debug\net8.0>BlackLineCountChecker.exe C:\user\Toyota\BlackLineCountChecker\images\img_1.jpg 
	C:\user\Toyota\BlackLineCountChecker\bin\Debug\net8.0>BlackLineCountChecker.exe C:\user\Toyota\BlackLineCountChecker\images\img_2.jpg
	C:\user\Toyota\BlackLineCountChecker\bin\Debug\net8.0>BlackLineCountChecker.exe C:\user\Toyota\BlackLineCountChecker\images\img_3.jpg
	C:\user\Toyota\BlackLineCountChecker\bin\Debug\net8.0>BlackLineCountChecker.exe C:\user\Toyota\BlackLineCountChecker\images\img_4.jpg
 

Output
------
The application will display:
 Image Name: img_2.jpg, Vertical Line Count: 3

Configuration
-------------
Edit appsettings.json to customize the black threshold:

{
  "ImageProcessing": {
    "BlackThreshold": 50
  }
}

BlackThreshold: 
- Introduced a configurable black threshold (default: 50).
- Pixels with RGB values below the threshold are treated as “black.”
               



