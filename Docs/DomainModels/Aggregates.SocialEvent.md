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
  "socialEventTypes": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "name": "concert",
      "subTypes": [
        "electronic",
        "dancel"
      ]
    }
  ],
  "tags": [
    {
      "name": "dance",
      "id": "00000000-0000-0000-0000-000000000000"
    }
  ],
  "createdDateTime": "22-06-26 02:31:29,573",
  "updatedDateTime": "22-06-26 02:31:29,573",
}
```