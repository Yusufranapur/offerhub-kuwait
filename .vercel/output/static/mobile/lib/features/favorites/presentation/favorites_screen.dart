import 'package:flutter/material.dart';
import 'package:offerhub_kuwait/l10n/app_localizations.dart';

class FavoritesScreen extends StatelessWidget {
  const FavoritesScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final l10n = AppLocalizations.of(context)!;

    return Scaffold(
      appBar: AppBar(
        title: Text(l10n.favorites),
      ),
      body: const Center(
        child: Text('No favorites yet'),
      ),
    );
  }
}

