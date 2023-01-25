namespace ComeSocial.Application.Contracts.Interest;

public record CreateInterestRequest(
    string Name,
    List<InterestTagsRequest> TagIds);

public record InterestTagsRequest(
    string Id
);