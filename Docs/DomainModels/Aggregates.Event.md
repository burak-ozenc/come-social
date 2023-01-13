# Domain Models - Event

```csharp
class Event
{
    void JoinEvent(Event event);
    void LeaveEvent(Event event);
    void UpdateEvent(Event event);
    List<Event> GetEvents();
}

```

```json
{
  "id": { "value": "00000000-0000-0000-0000-000000000000" },
  "name": "Stromae",
  "subHeader": "Niceu Concerto",
  "description": "A loooong description formatted with or HTML",
  "date": "22-06-26 02:31:29,573",
  "createdDateTime": "22-06-26 02:31:29,573",
  "updatedDateTime": "22-06-26 02:31:29,573",
  "eventType": {
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "name": "Concerto",
    "subType" : "Pop"
  },
  "groupIds": [
    {
      "id": { "value": "00000000-0000-0000-0000-000000000000" },
      "userIds": [
        { "value": "00000000-0000-0000-0000-000000000000" },
        { "value": "00000000-0000-0000-0000-000000000000" },
        { "value": "00000000-0000-0000-0000-000000000000" }
      ]
    }
  ],
  "tagIds": [
    { "value": "00000000-0000-0000-0000-000000000000" },
    { "value": "00000000-0000-0000-0000-000000000000" },
    { "value": "00000000-0000-0000-0000-000000000000" }
  ]
}
```