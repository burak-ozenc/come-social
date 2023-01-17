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
      "name": "concert",
      "subTypes": [
        "electronic",
        "dancel"
      ]
    },
    {
      "name": "musika",
      "subTypes": [
        "electronic",
        "dance"
      ]
    }
  ],
  "tags": [
    {
      "name": "dance",
      "id": "00000000-0000-0000-0000-000000000000"
    },
    {
      "name": "electronic",
      "id": "00000000-0000-0000-0000-000000000000"
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
  "id": "8613c3d7-158f-4995-800e-b9a8d9b50450",
  "name": "Stromae",
  "subHeader": "Niceu Concerto",
  "description": "A loooong description formatted with HTML",
  "date": "2015-05-16T12:50:06.7199222+03:00",
  "socialEventTypes": [
    {
      "name": "concert",
      "subTypes": [
        "electronic",
        "dancel"
      ]
    },
    {
      "name": "musika",
      "subTypes": [
        "electronic",
        "dance"
      ]
    }
  ],
  "tags": [
    {
      "id": "0b6fe9ca-ba04-450d-a115-5658dd489de2",
      "name": "dance"
    },
    {
      "id": "14db4747-5dcd-4b6a-b7f4-4b7ba4298935",
      "name": "electronic"
    }
  ],
  "createdDateTime" :"2015-05-16T05:50:06.7199222-04:00",
  "updatedDateTime" :"2015-05-16T05:50:06.7199222-04:00"
}
```