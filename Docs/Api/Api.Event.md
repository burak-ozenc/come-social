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
  "eventType": [
    {
      "type": 1,
      "subTypes": [
        "electronic",
        "dance"
      ]
    },
    {
      "type": 2,
      "subTypes": [
        "electronic",
        "dance"
      ]
    }
  ],
  "tags": [
    {
      "name": "dance"
    },
    {
      "name": "electronic"
    }
  ]
}
```



## CreateEventResponse
```
200 OK
```

```json
{
  "name": "Stromae",
  "subHeader": "Niceu Concerto",
  "description": "A loooong description formatted with HTML",
  "date": "22-06-26 02:31:29,573",
  "createdDateTime": "22-06-26 02:31:29,573",
  "updatedDateTime": "22-06-26 02:31:29,573",
  "eventType": {
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "name": "Concerto",
    "subType" : "Pop"
  },
  "tags": [
    { 
      "value": "00000000-0000-0000-0000-000000000000",
      "name" : "dance"
    },
    { 
      "value": "00000000-0000-0000-0000-000000000000",
      "name" : "electronic"
    },
    { 
      "value": "00000000-0000-0000-0000-000000000000",
      "name" : "live performance"
    }
  ]
}
```