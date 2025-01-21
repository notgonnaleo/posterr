export const endpoint = import.meta.env.VITE_BASE_URL;

// You might see a "mockuser context" on feed or other components, that's a fake user context mimicking Redux or React context API
// to set a user to post or repost, we are just updating the UserID here.
export const sampleUserId = 1; // Leonardo Bruni's UserID