export const fetchData = (url: string) => {
    return fetch(url)
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .catch(error => {
        console.error('Error:', error);
      });
  }


export const postData = (url: string, data: object) => {
    return fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    })
      .then(response => {
        if (!response.ok) {
            console.log(response);
            console.log(response.json());
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .catch(error => {
        console.error('Error:', error);
      });
  };
  
export const putData = (url: string, data: object) => {
    return fetch(url, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    })
      .then(response => {
        if (!response.ok) {
          console.log(response);
          console.log(response.json());
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .catch(error => {
        console.error('Error:', error);
      });
  };
  
export const deleteData = (url: string) => {
    return fetch(url, {
      method: 'DELETE',
    })
      .then(response => {
        if (!response.ok) {
          console.log(response);
          console.log(response.json());
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .catch(error => {
        console.error('Error:', error);
      });
  };
  