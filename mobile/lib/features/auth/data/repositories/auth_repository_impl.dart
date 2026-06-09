import 'package:dio/dio.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

import '../../../../core/constants/app_constants.dart';
import '../../../../core/errors/app_exception.dart';
import '../../../../core/network/dio_client.dart';
import '../../../../core/network/jwt_interceptor.dart';
import '../../domain/models/user_model.dart';
import '../../domain/repositories/auth_repository.dart';

part 'auth_repository_impl.g.dart';

@riverpod
AuthRepository authRepository(Ref ref) {
  return AuthRepositoryImpl(
    ref.read(dioClientProvider),
    ref.read(secureStorageProvider),
  );
}

class AuthRepositoryImpl implements AuthRepository {
  final Dio _dio;
  final FlutterSecureStorage _secureStorage;

  AuthRepositoryImpl(this._dio, this._secureStorage);

  @override
  Future<UserModel> login(String email, String password) async {
    try {
      final response = await _dio.post('/auth/login', data: {
        'email': email,
        'password': password,
      });

      final token = response.data['token'];
      await _secureStorage.write(key: AppConstants.tokenKey, value: token);

      return UserModel.fromJson(response.data['user']);
    } on DioException catch (e) {
      throw NetworkException.fromDioError(e);
    } catch (e) {
      throw AuthException(e.toString());
    }
  }

  @override
  Future<void> logout() async {
    await _secureStorage.delete(key: AppConstants.tokenKey);
  }

  @override
  Future<UserModel?> getCurrentUser() async {
    final token = await _secureStorage.read(key: AppConstants.tokenKey);
    if (token == null) return null;

    try {
      final response = await _dio.get('/auth/me');
      return UserModel.fromJson(response.data['user']);
    } catch (e) {
      return null;
    }
  }
}
