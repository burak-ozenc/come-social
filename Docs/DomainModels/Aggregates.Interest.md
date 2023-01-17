# Domain Models - Group

```csharp
class Interest
{
    void CreateInterest(Interest interest);
    void AddTagsToInterest(Interest interest, List<Tag> tags);
    void RemoveInterest(Interest interest);
    List<Interest> GetInterests(List<Tag> tags);
}
```

```json
{
  "id": { "value": "00000000-0000-0000-0000-000000000000" },
  "createdDateTime": "2015-05-16T05:50:06.7199222-04:00",
  "updatedDateTime": "2015-05-16T05:50:06.7199222-04:00",
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

