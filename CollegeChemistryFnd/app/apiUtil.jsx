// apiUtil.jsx

/**
 * Generic function to fetch data with Basic Authentication.
 * @param {string} url - The API endpoint.
 * @returns {Promise<any>} - The fetched data or an error.
 */
export const fetchDataWithAuth = async (url) => {
  try {
    const username = '11193466';
    const password = '60-dayfreetrial';
    
    // Use Buffer for base64 encoding (works in Node.js and browsers)
    const authHeader = 'Basic ' + Buffer.from(username + ':' + password).toString('base64');

    // Make the fetch request
    const response = await fetch(url, {
      method: 'GET',
      headers: {
        'Authorization': authHeader,
        'Content-Type': 'application/json',
      },
    });

    // Check if the response is ok (status code 200-299)
    if (!response.ok) {
      throw new Error(`Error: ${response.statusText}`);
    }

    // Parse the JSON response
    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Error fetching data:', error);
    throw error;
  }
};
