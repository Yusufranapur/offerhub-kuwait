import 'dart:io';

class AppConstants {
  AppConstants._();

  static String get baseUrl {
    if (Platform.isAndroid) {
      return 'http://10.0.2.2:5000/api'; // Android Emulator
    }
    return 'http://localhost:5000/api'; // Windows / Web / iOS Simulator
  }
  static const int connectionTimeout = 30000;
  static const int receiveTimeout = 30000;
  
  // SharedPreferences Keys
  static const String tokenKey = 'auth_token';
  static const String themeKey = 'theme_mode';
  static const String localeKey = 'app_locale';
}
