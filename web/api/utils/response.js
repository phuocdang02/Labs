module.exports = {
  success(data = {}, message = "Success", code = 200) {
    return {
      success: true,
      code: code,
      message: message,
      data: data,
    };
  },
  error(message = "Error", code = 500, error = null) {
    return {
      success: false,
      code,
      message,
      error,
    };
  },
  validationError(message, data = {}) {
    return {
      success: false,
      code: 400, // Bad Request
      message,
      error: data,
    };
  },
  notFound(message = "Resource not found") {
    return {
      success: false,
      code: 404, // Not Found
      message,
    };
  },
  unauthorized(message = "Unauthorized access") {
    return {
      success: false,
      code: 401, // Unauthorized
      message,
    };
  },
  forbidden(message = "Forbidden action") {
    return {
      success: false,
      code: 403, // Forbidden
      message,
    };
  },
  internalServerError(message = "Internal server error") {
    return {
      success: false,
      code: 500, // Internal Server Error
      message,
    };
  },
};


// const response = require("./utils/response");
// Example usage of different response handlers
// const validationError = response.validationError("Invalid email format");
// const notFound = response.notFound("User with ID 123 not found");
// const unauthorized = response.unauthorized();
// const forbidden = response.forbidden(
//   "You don't have permission to perform this action"
// );
// const internalServerError = response.internalServerError(
//   "Database connection error"
// );
