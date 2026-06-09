import 'package:flutter/material.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../constants/app_constants.dart';
import '../utils/shared_prefs_provider.dart';

part 'theme_provider.g.dart';

@riverpod
class ThemeModeNotifier extends _$ThemeModeNotifier {
  @override
  ThemeMode build() {
    final prefs = ref.watch(sharedPreferencesProvider);
    final themeStr = prefs.getString(AppConstants.themeKey);
    if (themeStr == 'light') return ThemeMode.light;
    if (themeStr == 'dark') return ThemeMode.dark;
    return ThemeMode.dark; // Premium dark mode default
  }

  Future<void> toggleTheme() async {
    final prefs = ref.read(sharedPreferencesProvider);
    final newMode = state == ThemeMode.dark ? ThemeMode.light : ThemeMode.dark;
    await prefs.setString(AppConstants.themeKey, newMode.name);
    state = newMode;
  }
  
  Future<void> setTheme(ThemeMode mode) async {
    final prefs = ref.read(sharedPreferencesProvider);
    await prefs.setString(AppConstants.themeKey, mode.name);
    state = mode;
  }
}

final themeModeProvider = themeModeNotifierProvider;
