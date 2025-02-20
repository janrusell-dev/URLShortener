# 🚀 URL Shortening Service  

A simple RESTful API for shortening long URLs, retrieving the original URLs, updating/deleting short URLs, and tracking usage statistics.  

This project is based on **[roadmap.sh - URL Shortening Service](https://roadmap.sh/projects/url-shortening-service).**  

---

## 📌 Features  
✅ Shorten long URLs  
✅ Retrieve original URLs  
✅ Update or delete shortened URLs  
✅ Get statistics on URL access  

---

## 🛠 Tech Stack  
- **Backend:** ASP.NET Core Web API  
- **Database:** MSSQL + Dapper  
- **Frontend (Optional):** HTML, CSS, JavaScript  
- **Tools:** Postman, Swagger UI  

---

## 🔗 Project URL  
[Live Demo](https://your-project-url.com)  

---

## 🔥 API Endpoints  

### 1️⃣ **Create a Short URL**  
**POST** `/shorten`  

```json
{
  "url": "https://www.example.com/some/long/url"
}
```
**Response:**  
```json
{
  "id": "1",
  "shortCode": "abc123",
  "createdAt": "2021-09-01T12:00:00Z"
}
```

---

### 2️⃣ **Retrieve the Original URL**  
**GET** `/shorten/abc123`  

**Response:**  
```json
{
  "id": "1",
  "url": "https://www.example.com/some/long/url",
  "shortCode": "abc123"
}
```

---

### 3️⃣ **Update an Existing Short URL**  
**PUT** `/shorten/abc123`  
```json
{
  "url": "https://www.example.com/some/updated/url"
}
```

---

### 4️⃣ **Delete a Short URL**  
**DELETE** `/shorten/abc123`  
_Response: `204 No Content`_

---

### 5️⃣ **Get URL Statistics**  
**GET** `/shorten/abc123/stats`  

```json
{
  "id": "1",
  "accessCount": 10
}


