module.exports = {
  root: true,
  env: {
    node: true,
  },
  extends: ['plugin:vue/vue3-essential', 'eslint:recommended'],
  rules: {
    'max-len': ['error', { 
      code: 250,
      ignoreComments: true, // We dont need to restrict the lenght of comments.
      ignoreUrls: true, // Same goes for URLs...
      ignoreStrings: true, // ...and long string definitions
    }],
    'comma-dangle': ['error', 'always-multiline'],
    semi: ['error', 'always'],
  },
};
