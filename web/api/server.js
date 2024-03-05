const express = require("express");

const cors = require("cors");
const bodyParser = require("body-parser");

const loginRoutes = require("./routes/loginRoutes");

const app = express();

app.use(cors());
app.use(bodyParser.json());

// console.log(validationError);
// console.log(notFound);
// console.log(unauthorized);
// console.log(forbidden);
// console.log(internalServerError);

// Routes
app.use("/api", loginRoutes);

const PORT = process.env.NODE_PORT || 3000;

app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
