﻿namespace ComeSocial.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail =>
            Error.Conflict(code: "User.DuplicateEmail", description: " Email is already in use.");
    }
}