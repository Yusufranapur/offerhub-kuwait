import 'package:flutter/material.dart';
import 'package:offerhub_kuwait/l10n/app_localizations.dart';

class NotificationsScreen extends StatelessWidget {
  const NotificationsScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final l10n = AppLocalizations.of(context)!;

    return Scaffold(
      appBar: AppBar(
        title: Text(l10n.notifications),
      ),
      body: const Center(
        child: Text('No new notifications'),
      ),
    );
  }
}

