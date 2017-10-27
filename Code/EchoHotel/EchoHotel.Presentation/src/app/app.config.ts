/*
    Arquivo de configurações básicas do App
*/

export class AppConfig {
    // esta string pode ser 'dev' ou 'prd'
    public static DESENVOLVIMENTO = 'dev';

    public static get BASE_URL(): string {
        if (AppConfig.DESENVOLVIMENTO === 'dev') {
            return 'http://localhost:52401/api';
        }else {
            return 'http://echohotel.azurewebsites.net/api';
        }
    }
}
