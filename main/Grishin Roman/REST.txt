RESTful URL's

-----------------
AccountController
-----------------
- Регистрироваться (anon)                                   POST    /api/users
- Входить в УЗ     (anon)                                   PUT     /api/users
- Выходить из УЗ                                            PUT     /api/users
- Просмотреть список пользователей (admin)                  GET     /api/users

-----------------
ManageController
-----------------
- Удалять УЗ                                                DELETE  /api/users/{id}
- Просматривать свой профиль                                GET     /api/users/{id}
- Редактировать свои данные                                 PUT     /api/users/{id}

-----------------
CartController
-----------------
- Просматривать свою корзину                                GET     /api/users/{id}/carts
- Добавлять товары в корзину                                POST    /api/users/{id}/carts
- Удалять товары из корзины                                 DELETE  /api/users/{id}/carts
- Изменять количество отдельного товара в корзине           PUT     /api/users/{id}/carts

-----------------
OrderController
-----------------
- Оформление заказа                                         POST    /api/users/{id}/orders
- Просмотр истории заказов                                  GET     /api/users/{id}/orders
- Просмотр деталей заказа                                   GET     /api/users/{id}/orders/{id}

-----------------
ProductController
-----------------
- Добавлять новый товар (admin)                             POST    /api/products
- Просматривать товарЫ (nonadmin)                           GET     /api/products   
- Изменять существующий товар (admin)                       PUT     /api/products/{id}
- Просматривать товар (nonadmin)                            GET     /api/products/{id}
- Удалять товар (admin)                                     DELETE  /api/products/{id}
                            
