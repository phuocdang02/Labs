// Importing the built-in 'fs' module for file operations
const fs = require("fs");

const inputFilePath = "data.js";

// Read the input file
fs.readFile(inputFilePath, "utf8", (err, data) => {
  if (err) {
    console.error("Error reading input file:", err);
    return;
  }

  // Print the content of the file before parsing
  console.log("Content of the file:", data);

  try {
    // Parse the content of the input file as a JavaScript object
    // Using for valid JSON
    // const myObject = JSON.parse(data);
    // Using eval comes with security risks, especially if the content of the file is not under your control.
    const myObject = eval(data);

    // Convert the JavaScript object to JSON
    const jsonString = JSON.stringify(myObject, null, 2);

    // Specify the output file path
    const outputFilePath = "readComplete.json";

    // Write the JSON data to a file
    fs.writeFile(outputFilePath, jsonString, (writeErr) => {
      if (writeErr) {
        console.error("Error writing JSON to file:", writeErr);
      } else {
        console.log(`JSON data has been written to ${outputFilePath}`);
      }
    });
  } catch (parseError) {
    console.error("Error parsing input data:", parseError);
  }
});
