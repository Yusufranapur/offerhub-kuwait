import 'package:flutter/material.dart';

class AppColors {
  AppColors._();

  // Premium Dark Mode Default (Deep Navy)
  static const Color backgroundDark = Color(0xFF0F172A);
  static const Color surfaceDark = Color(0xFF1E293B);
  
  // Light Mode Colors
  static const Color backgroundLight = Color(0xFFF8FAFC);
  static const Color surfaceLight = Color(0xFFFFFFFF);

  // Accents (Gold and Teal)
  static const Color goldAccent = Color(0xFFD4A843);
  static const Color tealAccent = Color(0xFF2DD4BF);
  static const Color primary = goldAccent;
  static const Color secondary = tealAccent;

  // Text Colors
  static const Color textPrimaryDark = Color(0xFFF8FAFC);
  static const Color textSecondaryDark = Color(0xFF94A3B8);
  
  static const Color textPrimaryLight = Color(0xFF0F172A);
  static const Color textSecondaryLight = Color(0xFF64748B);

  // Status Colors
  static const Color error = Color(0xFFEF4444);
  static const Color success = Color(0xFF22C55E);
  static const Color warning = Color(0xFFF59E0B);
}
