import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:offerhub_kuwait/l10n/app_localizations.dart';
import 'package:go_router/go_router.dart';
import '../../../core/theme/theme_provider.dart';
import '../../../core/l10n/locale_provider.dart';

class ProfileScreen extends ConsumerWidget {
  const ProfileScreen({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final l10n = AppLocalizations.of(context)!;

    return Scaffold(
      appBar: AppBar(
        title: Text(l10n.profile),
      ),
      body: ListView(
        padding: const EdgeInsets.all(16),
        children: [
          const CircleAvatar(
            radius: 50,
            child: Icon(CupertinoIcons.person, size: 50),
          ),
          const SizedBox(height: 16),
          const Center(
            child: Text(
              'User Name',
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
          ),
          const SizedBox(height: 32),
          ListTile(
            leading: const Icon(CupertinoIcons.heart),
            title: Text(l10n.favorites),
            trailing: const Icon(Icons.chevron_right),
            onTap: () => context.push('/profile/favorites'),
          ),
          SwitchListTile(
            secondary: const Icon(CupertinoIcons.moon),
            title: Text(l10n.theme),
            value: ref.watch(themeModeProvider) == ThemeMode.dark,
            onChanged: (_) => ref.read(themeModeProvider.notifier).toggleTheme(),
          ),
          ListTile(
            leading: const Icon(CupertinoIcons.globe),
            title: Text(l10n.language),
            trailing: Text(ref.watch(localeProvider).languageCode.toUpperCase()),
            onTap: () => ref.read(localeProvider.notifier).toggleLocale(),
          ),
          const SizedBox(height: 32),
          ListTile(
            leading: const Icon(CupertinoIcons.square_arrow_right, color: Colors.red),
            title: Text(l10n.logout, style: const TextStyle(color: Colors.red)),
            onTap: () => context.go('/login'),
          ),
        ],
      ),
    );
  }
}

