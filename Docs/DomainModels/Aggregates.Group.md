# Domain Models - Group

```csharp
class Group
{
    void CreateGroup(Group group);
    void JoinGroup(Group group);
    void LeaveGroup(Group group);
    List<Event> GetGroups(bool isVisible);
}

```
```json
{
  "id": { "value": "00000000-0000-0000-0000-000000000000" },
  "name": "This field be will auto generated, will be concat of usernames",
  "description": "Optional field",
  "eventDate": "22-06-26 02:31:29,573",
  "groupAvatar": "Optional field",
  "createdDateTime": "22-06-26 02:31:29,573",
  "updatedDateTime": "22-06-26 02:31:29,573",
  "eventId": { "value": "00000000-0000-0000-0000-000000000000" },
  "userIds": [
    { "value": "00000000-0000-0000-0000-000000000000" },
    { "value": "00000000-0000-0000-0000-000000000000" },
    { "value": "00000000-0000-0000-0000-000000000000" }
  ]
}
```