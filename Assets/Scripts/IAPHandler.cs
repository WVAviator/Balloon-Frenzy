using UnityEngine;
using System.Collections;
using UnityEngine.Purchasing;
using System;

public class IAPHandler : MonoBehaviour, IStoreListener {

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    private static string productIDRemoveAds = "removeads";
    private static string productIDGooglePlayRemoveAds = "removeads";

    private static string productID500Coins = "coins500";
    private static string productIDGooglePlay500Coins = "coins500";

    void Start()
    {
        if (m_StoreController == null) InitializePurchasing(); 
               
        CheckPreviousPurchases();
    }

    void InitializePurchasing()
    {
        if (IsInitialized()) return;

        ConfigurationBuilder builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(productIDRemoveAds, ProductType.NonConsumable, new IDs() { productIDGooglePlayRemoveAds, GooglePlay.Name });
        builder.AddProduct(productID500Coins, ProductType.Consumable, new IDs() { productIDGooglePlay500Coins, GooglePlay.Name });
        UnityPurchasing.Initialize(this, builder);

    }

    public void Buy500Coins()
    {
        
        try
        {
            if (IsInitialized())
            {
                Product product = m_StoreController.products.WithID(productID500Coins);
                if (product != null && product.availableToPurchase) m_StoreController.InitiatePurchase(product);                
            }
        }
        catch { }
    }

    public void BuyRemoveAds()
    {
        try
        {
            if (IsInitialized())
            {
                Product product = m_StoreController.products.WithID(productIDRemoveAds);
                if (product != null && product.availableToPurchase) m_StoreController.InitiatePurchase(product);               
            }
        }
        catch { }
    }

    public void CheckPreviousPurchases()
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productIDRemoveAds);
            if (product != null && product.hasReceipt) PlayerManager.DisableAds();            
        }
    }

    bool IsInitialized()
    {
        return (m_StoreController != null && m_StoreExtensionProvider != null);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        throw new NotImplementedException();
    }

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        throw new NotImplementedException();
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (String.Equals(e.purchasedProduct.definition.id, productIDRemoveAds, StringComparison.Ordinal))
        {
            PlayerManager.DisableAds();
        }
        else if (String.Equals(e.purchasedProduct.definition.id, productID500Coins, StringComparison.Ordinal))
        {
            PlayerManager.AddCoins(500);
            PlayerManager.SaveCoins();
        }
        else
        {
            Debug.Log("Purchase failed");
        }
        return PurchaseProcessingResult.Complete;
    }

}
