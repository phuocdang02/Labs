const { v4: uuidv4 } = require("uuid");

const bcrypt = require("bcrypt");
const jwt = require("jsonwebtoken");
const response = require("../utils/response");
const userService = require("../services/userService");

exports.login = async (req, res) => {
  try {
    const { username, password } = req.body;
    const user = await userService.checkAccount(username, password);

    if (!user) {
      return res
        .status(401)
        .json(response.unauthorized("Invalid username or password"));
    }
    const checkpass = await bcrypt.compare(password, user.hashpassword);
    if (!checkpass) {
      return res.status(401).json(response.unauthorized("Invalid password"));
    }

    // Generate the token

    return res.status(200).json(response.success({ user, token }));
  } catch (error) {
    res.status(500).json(response.error());
  }
};

exports.register = async (req, res) => {
  try {
    const { username, password } = req.body;

    //Check duplicate phonenumber or email
    const check = await userService.checkAccount(username, email);
    if (!check) {
      return res
        .status(400)
        .json(response.validationError("Invalid username or email"));
    }

    // Generate hash password for new user
    const hashpassword = await bcrypt.hash(password, 10);

    // Generate user information
    await userService.insert({
      id: uuidv4(),
      username,
      hashpassword: hashpassword,
    });

    return res.status(201).json(response.success(req.body));
  } catch (error) {
    res.status(500).json(response.error());
  }
};
