/**
 * A utility class that provides several string-related helper methods.
 * @class
 */
class StringHelper {
    /**
     * Checks whether a string is null, undefined, empty, or consists only of whitespace characters.
     * @param {string} whatToCheck - The string to check.
     * @param {boolean} checkEmptyToo - Whether to consider an empty string as invalid.
     * @returns {boolean} - True if the string is invalid; otherwise, false.
     */
    static isNullOrWhitespace(whatToCheck, checkEmptyToo = false) {
      if (whatToCheck == null) return true; // Checks both null and undefined due to type coercion
      if (checkEmptyToo && whatToCheck === '') return true;
      
      return /^\s*$/.test(whatToCheck);
    }
  
    /**
     * Capitalizes the first letter of a string.
     * @param {string} str - The string to capitalize.
     * @returns {string} - The input string with the first letter capitalized.
     */
    static capitalizeFirstLetter(str) {
      if (!str || typeof str !== 'string') return str;
      return str.charAt(0).toUpperCase() + str.slice(1);
    }
  
    /**
     * Checks whether a string contains only numeric characters.
     * @param {string} str - The string to check.
     * @returns {boolean} - True if the string contains only numeric characters; otherwise, false.
     */
    static isNumeric(str) {
      return /^\d+$/.test(str);
    }
  
    /**
     * Trims all whitespace characters from the start and end of a string and replaces consecutive whitespace characters inside the string with a single space.
     * @param {string} str - The string to normalize.
     * @returns {string} - The normalized string.
     */
    static normalizeWhitespace(str) {
      return str && str.replace(/\s+/g, ' ').trim();
    }
  }
  
  export default StringHelper;  