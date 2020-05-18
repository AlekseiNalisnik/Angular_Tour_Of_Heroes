# REST API

## Table of contents

- [API](#API)

- [Account](#Account)

- [Users](#Users)

- [Search](#Search)

- [Cart](#Cart)

- [Orders](#Orders)

- [Products](#Products)

----

## <a name="API"></a> /API

## <a name="Account"></a> /Account

|Action                           |Rights  |Verb        |URI
|---------------------------------|--------|------------|-----------
|Регистрироваться                 |*anon*  |**POST**    |`/register`
|Входить в УЗ                     |*anon*  |**PUT**     |`/login`
|Выходить из УЗ                   |*auth*  |**PUT**     |`/logout`
|Удалять УЗ                       |*auth*  |**DELETE**  |
|Просматривать свой профиль       |*auth*  |**GET**     |
|Редактировать свои данные        |*auth*  |**PUT**     |

## <a name="Users"></a> /Users

|Action                           |Rights  |Verb      |URI
|---------------------------------|--------|----------|-----------
|Просмотреть список пользователей |*admin* |**GET**   |

## <a name="Search"></a> /Search

|Action                           |Rights  |Verb      |URI
|---------------------------------|--------|----------|-----------
|Search query                     |*anon*  |**GET**   |?query={query_string}

## <a name="Cart"></a> /Cart

|Action                           |Rights  |Verb        |URI
|---------------------------------|--------|------------|-----------
|Просматривать свою корзину       |*auth*  |**GET**     |

## <a name="Orders"></a> /Orders

|Action                           |Rights  |Verb        |URI
|---------------------------------|--------|------------|-----------
|Просмотр истории заказов         |*auth*  |**GET**     |
|Просмотр деталей заказа          |*auth*  |**GET**     |`/{id}`
|Оформление заказа                |*auth*  |**POST**    |`/checkout`

## <a name="Products"></a> /Products

|Action                           |Rights  |Verb        |URI
|---------------------------------|--------|------------|-----------
|Добавлять новый товар            |*admin* |**POST**    |
|Удалять товар                    |*admin* |**DELETE**  |`/{id}`
|Изменять существующий товар      |*admin* |**PUT**     |`/{id}`
|Просматривать товары             |*anon*  |**GET**     |  
|Просматривать товар              |*anon*  |**GET**     |`{id}`
|Добавлять товар в корзину        |*anon*  |**POST**    |`/addtocart?id={product_id}&count={product_count}`  
|Добавлять товар в корзину        |*anon*  |**DELETE**  |`/deletefromcart?id={product_id}&count={product_count}` 

