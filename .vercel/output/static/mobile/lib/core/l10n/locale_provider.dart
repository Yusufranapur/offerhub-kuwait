import 'package:flutter/material.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../constants/app_constants.dart';
import '../utils/shared_prefs_provider.dart';

part 'locale_provider.g.dart';

@riverpod
class LocaleNotifier extends _$LocaleNotifier {
  @override
  Locale build() {
    final prefs = ref.watch(sharedPreferencesProvider);
    final langStr = prefs.getString(AppConstants.localeKey);
    if (langStr != null) {
      return Locale(langStr);
    }
    return const Locale('en'); // Default to English
  }

  Future<void> setLocale(Locale locale) async {
    if (!['en', 'ar'].contains(locale.languageCode)) return;
    
    final prefs = ref.read(sharedPreferencesProvider);
    await prefs.setString(AppConstants.localeKey, locale.languageCode);
    state = locale;
  }
  
  Future<void> toggleLocale() async {
    final newLocale = state.languageCode == 'en' ? const Locale('ar') : const Locale('en');
    await setLocale(newLocale);
  }
}

final localeProvider = localeNotifierProvider;
