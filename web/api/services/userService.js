const User = require("../models/Users");

exports.insert = async (data) => {
  try {
    const result = await User.insert(data);
    return result;
  } catch (error) {
    throw new Error(error);
  }
};

exports.checkAccount = async (username, email) => {
  try {
    const user = await User.checkUsernameOrEmail(username, email);
    return user;
  } catch (error) {
    throw new Error(error);
  }
};
