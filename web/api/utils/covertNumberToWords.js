const { toWords } = require("number-to-words");

function convertPriceToWords(price) {
  const words = toWords(price);
  return words.charAt(0).toUpperCase() + words.slice(1); // Capitalize the first letter
}

export default convertPriceToWords;
