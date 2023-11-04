/**
 * A utility class for handling cookies.
 * @class
 */
class CookieHelper {
  /**
   * Set or create a cookie.
   * @param {string} name - The name of the cookie.
   * @param {string} value - The value of the cookie.
   * @param {number} [days=7] - The number of days until the cookie will expire.
   * @param {string} [path='/'] - The path of the cookie.
   */
  static set(name, value, days = 7, path = '/') {
    // Calculate the expiration date of the cookie.
    const expires = new Date(Date.now() + days * 864e5).toUTCString();

    // Set the cookie.
    document.cookie = `${name}=${encodeURIComponent(value)}; expires=${expires}; path=${path}`;
  }

  /**
   * Sets a cookie with a specified name and value, designating it to expire in 100 years,
   * effectively allowing the cookie to last "forever" for most practical purposes.
   *
   * @param {string} name - The name of the cookie.
   * @param {string} value - The value of the cookie.
   * @param {string} [path='/'] - The path where the cookie is accessible.
   */
  static setForever(name, value, path = '/') {
    // Set the expiration date to a date 100 years in the future.
    const expires = new Date(Date.now() + 100 * 365 * 24 * 60 * 60 * 1000).toUTCString(); // 100 years in milliseconds

    // Set the cookie with the calculated expiration date.
    document.cookie = name + '=' + encodeURIComponent(value) + '; expires=' + expires + '; path=' + path;
  }

  /**
   * Retrieve the value of a cookie.
   * @param {string} name - The name of the cookie.
   * @returns {string} - The value of the cookie.
   */
  static get(name) {
    // Parse cookies string and reduce it to find the named cookie value.
    return document.cookie.split('; ').reduce((r, v) => {
      const parts = v.split('=');
      return parts[0] === name ? decodeURIComponent(parts[1]) : r;
    }, '');
  }

  /**
   * Delete a cookie.
   * @param {string} name - The name of the cookie.
   * @param {string} [path='/'] - The path of the cookie.
   */
  static delete(name, path = '/') {
    // Set the cookie with a past expiration date to delete it.
    this.set(name, '', -1, path);
  }
}

export default CookieHelper;
