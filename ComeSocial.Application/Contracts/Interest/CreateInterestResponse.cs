namespace ComeSocial.Application.Contracts.Interest;

public record CreateInterestResponse(
    string Id,
    string Name,
    List<InterestTagResponse> TagIds,
    DateTime? CreatedDateTime,
    DateTime? UpdatedDateTime
    );
    
public record InterestTagResponse(string Id, string Name);