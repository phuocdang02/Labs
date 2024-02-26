import User from "../models/Users";

exports.insertUser = async (data) => {
  try {
    const result = await User.insert(data);
    return result;
  } catch (error) {
    throw new Error(error);
  }
};

exports.checkAccount = async (username, email) => {
  try {
    const user = await User.getUsernameOrEmail(username, email);
    return user;
  } catch (error) {
    throw new Error(error);
  }
};
