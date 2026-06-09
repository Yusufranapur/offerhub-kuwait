import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:offerhub_kuwait/l10n/app_localizations.dart';
import '../../../core/constants/app_colors.dart';

class MainScreen extends StatelessWidget {
  final StatefulNavigationShell navigationShell;

  const MainScreen({super.key, required this.navigationShell});

  @override
  Widget build(BuildContext context) {
    final l10n = AppLocalizations.of(context)!;

    return Scaffold(
      body: navigationShell,
      bottomNavigationBar: BottomNavigationBar(
        currentIndex: navigationShell.currentIndex,
        onTap: (index) {
          navigationShell.goBranch(
            index,
            initialLocation: index == navigationShell.currentIndex,
          );
        },
        items: [
          BottomNavigationBarItem(
            icon: const Icon(CupertinoIcons.home),
            activeIcon: const Icon(CupertinoIcons.house_fill),
            label: l10n.home,
          ),
          BottomNavigationBarItem(
            icon: const Icon(CupertinoIcons.search),
            activeIcon: const Icon(CupertinoIcons.search, color: AppColors.primary),
            label: l10n.search,
          ),
          BottomNavigationBarItem(
            icon: const Icon(CupertinoIcons.tag),
            activeIcon: const Icon(CupertinoIcons.tag_fill),
            label: l10n.offers,
          ),
          BottomNavigationBarItem(
            icon: const Icon(CupertinoIcons.creditcard),
            activeIcon: const Icon(CupertinoIcons.creditcard_fill),
            label: l10n.wallet,
          ),
          BottomNavigationBarItem(
            icon: const Icon(CupertinoIcons.person),
            activeIcon: const Icon(CupertinoIcons.person_solid),
            label: l10n.profile,
          ),
        ],
      ),
    );
  }
}

