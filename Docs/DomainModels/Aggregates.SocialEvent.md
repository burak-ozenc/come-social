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
  "description": "A loooong description formatted with HTML",
  "date": "2015-05-16T12:50:06.7199222+03:00",
  "comeEventTypes": [
    {
      "id": { "value": "00000000-0000-0000-0000-000000000000" },
      "name": null
    }
  ],
  "tags": [
    {
      "id": { "value": "00000000-0000-0000-0000-000000000000" },
      "name": null
    }
  ],
  "createdDateTime": "2023-01-24T03:54:17.2071905+03:00",
  "updatedDateTime": null
}
```