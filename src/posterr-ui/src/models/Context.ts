export interface UserContext {
    UserId: number,
    // Then we would have other properties like
    // Username, UserRoles, UserClaims, UserThemePreferences, UserContactEmail
    // any other information that we could rely on the temporary storage to generate a context
    // I'm just creating the model here to illustrate the design idea
}