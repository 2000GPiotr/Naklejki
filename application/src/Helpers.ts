export const fetchData = async (url: string) => {
  try {
    const response = await fetch(url);

    if (!response.ok) {
      throw new Error('Network response was not ok');
    }

    return response.json();
  } 
  catch (error) {
    console.error('Error:', error);
  }
};


export const postData = async (url: string, data: object) => {
  try {
    const response = await fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      console.log(response);
      console.log(await response.json());
      throw new Error('Network response was not ok');
    }

    return response.json();
  } 
  catch (error) {
    console.error('Error:', error);
  }
};


export const putData = async (url: string, data: object) => {
  try {
    const response = await fetch(url, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      console.log(response);
      console.log(await response.json());
      throw new Error('Network response was not ok');
    }

    return response.json();
  } 
  catch (error) {
    console.error('Error:', error);
  }
};


export const deleteData = async (url: string) => {
  try {
    const response = await fetch(url, {
      method: 'DELETE',
    });

    if (!response.ok) {
      console.log(response);
      console.log(await response.json());
      throw new Error('Network response was not ok');
    }

    return response.json();
  } 
  catch (error) {
    console.error('Error:', error);
  }
};
