import React from "react";
import { Suspense } from "react";
import { AppProvider } from "./app-provider";
import { unstable_noStore as noStore } from "next/cache";
import { AntdRegistry } from "@ant-design/nextjs-registry";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  noStore();
  const backendUrl =
    process.env.NEXT_PUBLIC_BACKEND_URL ?? "http://localhost:21021";

  return (
    <html lang="en">
      <head>
        {/* Google Tag Manager */}
        <script
          async
          src="https://www.googletagmanager.com/gtag/js?id=G-LJWKP0P3L7"
        ></script>
        <script
          dangerouslySetInnerHTML={{
            __html: `
            window.dataLayer = window.dataLayer || [];
            function gtag(){dataLayer.push(arguments);}
            gtag('js', new Date());
            gtag('config', 'G-LJWKP0P3L7');
          `,
          }}
        />
        {/* End Google Tag Manager */}
      </head>
      <body>
        <Suspense>
          <AntdRegistry>
            <AppProvider backendUrl={backendUrl}>{children}</AppProvider>
          </AntdRegistry>
        </Suspense>
      </body>
    </html>
  );
}
