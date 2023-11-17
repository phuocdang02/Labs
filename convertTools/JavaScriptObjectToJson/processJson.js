const fs = require('fs');
const { v4: uuidv4 } = require('uuid');

const inputFile = 'convert_data.json';
const outputFile = 'converted.json';

// Define a map for predefined layerId values based on layer_id
const layerIdMap = {
  "1": "085fd501-3f96-4027-b85d-938f51a3ee7f",
  "2": "76fe0cb2-51f8-4ba2-8155-0311910fee0a",
  "3": "0023e2dc-dbca-4137-9286-fa03178b5d4b",
  "4": "0bd478d1-8c92-4a55-ba56-346690eab37e",
  "5": "0f7254e6-0499-4727-8939-a3f1a5567163",
  "6": "8ad67270-bf8c-4f99-a8f1-b4fee446134c",
  "7": "39143e6d-d823-48b7-a05d-e0e8091ebc79",
  "8": "57232677-6b7a-4908-8f9f-d29ed8d9b8c2",
  "9": "e3bebb6b-317f-4ace-b816-0f260e1d8fa8",
  "10": "a4a1d510-f693-4d7f-aef0-5a8547b5f4be",
};

fs.readFile(inputFile, 'utf8', (err, data) => {
  if (err) {
    console.error(`Error reading the input file: ${err}`);
    return;
  }

  try {
    const jsonData = JSON.parse(data);

    const newData = jsonData.map(({ cameraId, layer_id, ...rest }) => {
      // Check if layer_id is in the layerIdMap
      if (layerIdMap.hasOwnProperty(layer_id)) {
        // Use the predefined layerId for the given layer_id
        const layerId = layerIdMap[layer_id];
        return { ...rest, layerId };
      } else {
        // Generate a random GUID for layerId for other cases
        const layerId = uuidv4();
        return { ...rest, layerId };
      }
    });

    const outputJson = JSON.stringify(newData, null, 2);

    fs.writeFile(outputFile, outputJson, 'utf8', (err) => {
      if (err) {
        console.error(`Error writing to the output file: ${err}`);
        return;
      }

      console.log(`Modified data saved to ${outputFile}`);
    });
  } catch (parseError) {
    console.error(`Error parsing JSON data: ${parseError}`);
  }
});
