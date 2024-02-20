const withBundleAnalyzer = require('@next/bundle-analyzer')({
  enabled: process.env.ANALYZE === 'true',
});
const moment = require('moment');
const isProd = process.env.NODE_ENV === 'production';

const nextConfig = () => {
  const env = {
    NEXT_APP_ENV: process.env.NEXT_APP_ENV ?? 'dev',
    //NEXT_APP_API_HOST: process.env.NEXT_APP_API_HOST,
  };
  /** @type {import('next').NextConfig} */
  const config = {
    //output: 'standalone',
    reactStrictMode: false,
    transpilePackages: [
      'antd',
      '@ant-design',
      'ant-design',
      'rc-align',
      'rc-cascader',
      'rc-checkbox',
      'rc-collapse',
      'rc-dialog',
      'rc-drawer',
      'rc-dropdown',
      'rc-field-form',
      'rc-image',
      'rc-input',
      'rc-input-number',
      'rc-mentions',
      'rc-menu',
      'rc-motion',
      'rc-notification',
      'rc-overflow',
      'rc-pagination',
      'rc-picker',
      'rc-progress',
      'rc-rate',
      'rc-resize-observer',
      'rc-segmented',
      'rc-select',
      'rc-slider',
      'rc-steps',
      'rc-switch',
      'rc-table',
      'rc-tabs',
      'rc-textarea',
      'rc-tooltip',
      'rc-tree',
      'rc-tree-select',
      'rc-trigger',
      'rc-upload',
      'rc-util',
      'rc-virtual-list'],
    poweredByHeader: false,
    productionBrowserSourceMaps: true,
    env,
    publicRuntimeConfig: env,
    compiler: {
      // Remove `console.*` output except `console.error`
      removeConsole: isProd
        ? {
          exclude: ['error'],
        }
        : false,
      // Uncomment this to suppress all logs.
      // removeConsole: true,
    },
  };
  return withBundleAnalyzer(
    config, {
    debug: !isProd,
    environment: process.env.NODE_ENV,
    release: `${process.env.NODE_ENV}@${moment().format('YYYY-MM-DD HH:mm')}`,
  }
  );
};

module.exports = nextConfig;
