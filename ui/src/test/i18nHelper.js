import { mount, shallow } from 'enzyme';
import I18nProvider from "../components/i18nProvider/I18nProvider";
import messages from "../locales/messages";
import { LOCALES, getLocaleCode } from "../locales/locales";

export function mountWithIntl(node, language ="en") {
    const locale = getLocaleCode(language);

    return mount(node, {
        wrappingComponent: I18nProvider,
        wrappingComponentProps: {
            locale: locale,
            defaultLocale: LOCALES.english,
            messages: messages[locale],
        },
    });
}

export function shallowWithIntl(node, language="en") {
    const locale = getLocaleCode(language);
    
    return shallow(node, {
        wrappingComponent: I18nProvider,
        wrappingComponentProps: {
            locale: locale,
            defaultLocale: LOCALES.english,
            messages: messages[locale],
        },
    });
}