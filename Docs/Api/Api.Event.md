# Api Models - Event

## 

### CreateEventRequest
```
POST /events/createEvent
```

```json
{
  "name": "Stromae",
  "subHeader": "Niceu Concerto",
  "description": "A loooong description formatted with HTML",
  "date": "2015-05-16T05:50:06.7199222-04:00",
  "socialEventTypes": [
    {
      "id": "706e8fd1-e81f-4478-86d6-f705a187b2fc",
      "name": "concert"
    }
  ],
  "tags": [
    {
      "id": "25c5eaf5-57f5-49eb-9740-5bc9b6fe6bc1",
      "name": "electronic"
    }
  ]
}
```



## CreateEventResponse
```
201 OK
```

```json
{
  "id": "7fc93629-86bc-41ce-a5b8-e92ea99943ab",
  "name": "Stromaeeaeae",
  "subHeader": "Niceu Concerto",
  "description": "A loooong description formatted with HTML",
  "date": "2015-05-16T12:50:06.7199222+03:00",
  "comeEventTypes": [
    {
      "id": "706e8fd1-e81f-4478-86d6-f705a187b2fc"
    }
  ],
  "tags": [
    {
      "id": "25c5eaf5-57f5-49eb-9740-5bc9b6fe6bc1"
    }
  ],
  "createdDateTime": "2023-01-24T03:54:17.2071905+03:00",
  "updatedDateTime": null
}
```