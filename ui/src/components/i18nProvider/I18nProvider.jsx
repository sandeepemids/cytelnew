import React, { Fragment } from "react";
import { LOCALES } from "../../locales/locales";
import { IntlProvider } from "react-intl";
import messages from "../../locales/messages";

const i18nProvider = ({ children, locale = LOCALES.english }) => (
  <IntlProvider
    locale={locale}
    defaultLocale={LOCALES.english}
    textComponent={Fragment}
    messages={messages[locale]}
  >
    {children}
  </IntlProvider>
);

export default i18nProvider;