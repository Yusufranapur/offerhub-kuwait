// =============================================
// OfferHub Kuwait Admin Portal - Type Definitions
// =============================================

// Auth & User Types
export interface AdminUser {
  id: string;
  email: string;
  name: string;
  role: 'super_admin' | 'admin' | 'moderator' | 'support';
  avatar?: string;
  permissions: string[];
  lastLogin?: string;
  createdAt: string;
  isActive: boolean;
}

export interface LoginCredentials {
  email: string;
  password: string;
}

export interface AuthResponse {
  token: string;
  refreshToken: string;
  user: AdminUser;
}

// Vendor Types
export interface Vendor {
  id: string;
  businessName: string;
  businessNameAr: string;
  ownerName: string;
  email: string;
  phone: string;
  logo?: string;
  coverImage?: string;
  description: string;
  descriptionAr: string;
  category: string;
  status: 'pending' | 'active' | 'suspended' | 'rejected';
  subscriptionPlan: string;
  subscriptionExpiry?: string;
  branches: Branch[];
  totalOffers: number;
  totalRedemptions: number;
  rating: number;
  joinedAt: string;
  rejectionReason?: string;
  documents: VendorDocument[];
}

export interface Branch {
  id: string;
  name: string;
  nameAr: string;
  address: string;
  addressAr: string;
  latitude: number;
  longitude: number;
  phone: string;
  isActive: boolean;
}

export interface VendorDocument {
  id: string;
  type: 'license' | 'id' | 'certificate' | 'other';
  name: string;
  url: string;
  uploadedAt: string;
  verified: boolean;
}

// Offer Types
export interface Offer {
  id: string;
  vendorId: string;
  vendorName: string;
  title: string;
  titleAr: string;
  description: string;
  descriptionAr: string;
  type: 'percentage' | 'fixed' | 'bogo' | 'free_item';
  discountValue: number;
  originalPrice?: number;
  thumbnail?: string;
  images: string[];
  category: string;
  status: 'pending' | 'active' | 'rejected' | 'expired' | 'paused';
  startDate: string;
  endDate: string;
  termsAndConditions: string;
  termsAndConditionsAr: string;
  maxRedemptions?: number;
  currentRedemptions: number;
  isFeatured: boolean;
  createdAt: string;
  rejectionReason?: string;
}

// Category Types
export interface Category {
  id: string;
  name: string;
  nameAr: string;
  icon: string;
  color: string;
  slug: string;
  parentId?: string;
  order: number;
  isActive: boolean;
  offerCount: number;
  vendorCount: number;
}

// Banner Types
export interface Banner {
  id: string;
  title: string;
  titleAr: string;
  image: string;
  imageAr?: string;
  type: 'hero' | 'promotional' | 'category' | 'vendor';
  linkType: 'offer' | 'vendor' | 'category' | 'url' | 'none';
  linkValue?: string;
  position: number;
  isActive: boolean;
  startDate: string;
  endDate: string;
  impressions: number;
  clicks: number;
  createdAt: string;
}

// Notification Types
export interface Notification {
  id: string;
  title: string;
  titleAr: string;
  body: string;
  bodyAr: string;
  type: 'broadcast' | 'targeted' | 'scheduled';
  targetAudience: 'all' | 'customers' | 'vendors' | 'specific';
  targetIds?: string[];
  scheduledAt?: string;
  sentAt?: string;
  status: 'draft' | 'scheduled' | 'sent' | 'failed';
  deliveredCount: number;
  openedCount: number;
  createdBy: string;
  createdAt: string;
}

// CMS Types
export interface CmsPage {
  id: string;
  slug: 'about' | 'terms' | 'privacy' | 'faq';
  title: string;
  titleAr: string;
  content: string;
  contentAr: string;
  lastUpdatedBy: string;
  updatedAt: string;
  isPublished: boolean;
}

export interface FaqItem {
  id: string;
  question: string;
  questionAr: string;
  answer: string;
  answerAr: string;
  order: number;
  isActive: boolean;
}

// Subscription Types
export interface SubscriptionPlan {
  id: string;
  name: string;
  nameAr: string;
  slug: 'basic' | 'pro' | 'premium';
  price: number;
  currency: string;
  billingCycle: 'monthly' | 'yearly';
  features: PlanFeature[];
  maxOffers: number;
  maxBranches: number;
  maxStaff: number;
  isPopular: boolean;
  isActive: boolean;
  subscriberCount: number;
  color: string;
}

export interface PlanFeature {
  id: string;
  name: string;
  nameAr: string;
  included: boolean;
}

// Analytics Types
export interface AnalyticsOverview {
  totalCustomers: number;
  customerGrowth: number;
  totalVendors: number;
  vendorGrowth: number;
  totalOffers: number;
  offerGrowth: number;
  totalClaims: number;
  claimGrowth: number;
  totalRedemptions: number;
  redemptionGrowth: number;
  totalRevenue: number;
  revenueGrowth: number;
}

export interface ChartDataPoint {
  date: string;
  label: string;
  value: number;
  value2?: number;
}

export interface TopVendor {
  id: string;
  name: string;
  logo?: string;
  revenue: number;
  redemptions: number;
  rating: number;
}

// Audit Types
export interface AuditLog {
  id: string;
  userId: string;
  userName: string;
  userRole: string;
  action: string;
  resource: string;
  resourceId: string;
  description: string;
  oldValues?: Record<string, unknown>;
  newValues?: Record<string, unknown>;
  ipAddress: string;
  userAgent: string;
  timestamp: string;
}

// Customer/User Types
export interface Customer {
  id: string;
  name: string;
  email: string;
  phone: string;
  avatar?: string;
  isActive: boolean;
  totalClaims: number;
  totalRedemptions: number;
  joinedAt: string;
  lastActiveAt: string;
}

// Activity Feed
export interface ActivityItem {
  id: string;
  type: 'vendor_registered' | 'offer_submitted' | 'offer_approved' | 'offer_rejected' | 'vendor_approved' | 'vendor_suspended' | 'payment_received' | 'user_registered';
  title: string;
  description: string;
  timestamp: string;
  actorName?: string;
  actorAvatar?: string;
  metadata?: Record<string, unknown>;
}

// Settings
export interface AppSettings {
  siteName: string;
  siteNameAr: string;
  logo?: string;
  favicon?: string;
  primaryColor: string;
  supportEmail: string;
  supportPhone: string;
  defaultLanguage: 'en' | 'ar';
  maintenanceMode: boolean;
  autoApproveVendors: boolean;
  autoApproveOffers: boolean;
  maxOffersPerVendor: number;
  commission: number;
  socialLinks: {
    instagram?: string;
    twitter?: string;
    facebook?: string;
    tiktok?: string;
  };
}

// API Types
export interface ApiResponse<T> {
  data: T;
  message: string;
  success: boolean;
}

export interface PaginatedResponse<T> {
  data: T[];
  total: number;
  page: number;
  limit: number;
  totalPages: number;
}

export interface PaginationParams {
  page: number;
  limit: number;
  search?: string;
  sortBy?: string;
  sortOrder?: 'asc' | 'desc';
  status?: string;
  startDate?: string;
  endDate?: string;
}

// Table column definition
export interface TableColumn<T> {
  key: keyof T | string;
  label: string;
  sortable?: boolean;
  render?: (value: unknown, row: T) => React.ReactNode;
  width?: string;
}

// Modal Types
export interface ModalProps {
  isOpen: boolean;
  onClose: () => void;
  title: string;
  children: React.ReactNode;
  size?: 'sm' | 'md' | 'lg' | 'xl';
}
