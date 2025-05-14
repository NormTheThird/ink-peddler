export let CONFIG = {
  Environments: { Prod: 'prod' },
  Environment(): string { return '{ci_build_environment}' },
  BaseUrl(): string {
    switch (CONFIG.Environment()) {
      case CONFIG.Environments.Prod: {
        return 'https://ink-peddler-api.azurewebsites.net/api';
      }
      default: {
        return 'https://ink-peddler-api-test.azurewebsites.net/api'
      }
    }
  },
  S3EnvKey(): string {
    switch (CONFIG.Environment()) {
      case CONFIG.Environments.Prod: {
        return 'prod';
      }
      default: {
        return 'staging';
      }
    }
  },
  S3CoverImageKey: '/cover/',
  S3ProfileImageKey: '/profile/',
  S3TattooImageKey: '/tattoo/',
  S3BucketName: 'ink-peddler-images',
  S3BaseUrl: 'https://s3.amazonaws.com/',
  S3AccessKey: 'AKIAIJ7NZKMKYE3FHNWA',
  S3SecretAccessKey: '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',
  AWSRegion: 'us-east-1',

}