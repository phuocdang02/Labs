import * as fs from "fs";
import { PdfReader } from "pdfreader";

const filePath = "External_Platform_Interface_Version_4.3-Data_Feed_Draft.pdf";
const outputFile = "extracted_text.txt";

let extractedText = "";

// new PdfReader().parseFileItems(filePath, (err, item) => {
//   if (err) {
//     console.error("error: ", err);
//     return; // Exit if there's an error
//   }

//   if (!item) {
//     console.warn("end of file");
//     // Write the accumulated text to the file
//     fs.writeFileSync(outputFile, extractedText);
//     console.log("Text saved to output file:", outputFile);
//     return; // Exit after writing
//   }

//   if (item.text) {
//     extractedText += item.text; // Append text to the string
//   }
// });

new PdfReader().parseFileItems(filePath, (err, item) => {
  if (err) console.error("error:", err);
  else if (!item) console.warn("end of file");
  else if (item.text) console.log(item.text);
});
