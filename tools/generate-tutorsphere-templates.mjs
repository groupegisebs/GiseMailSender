import fs from "fs";
import path from "path";
import { fileURLToPath } from "url";

const __dirname = path.dirname(fileURLToPath(import.meta.url));
const outPath = path.join(__dirname, "../src/SecureMailGateway/Data/TutorSphereTemplates.cs");

const LANGS = ["fr", "en", "es", "de", "pt", "zh-Hans", "ar"];
/** Incrémentez REV pour forcer l'upsert au démarrage (y compris écrasement des stubs AUTO). */
const REV = 7;

/** @typedef {{fr:string,en:string,es:string,de:string,pt:string,zh:string,ar:string}} Loc */

/** @param {Loc} l @param {string} lang */
function t(l, lang) {
  switch (lang) {
    case "en": return l.en;
    case "es": return l.es;
    case "de": return l.de;
    case "pt": return l.pt;
    case "zh-Hans": return l.zh;
    case "ar": return l.ar;
    default: return l.fr;
  }
}

/** @param {...string} parts */
function L(fr, en, es, de, pt, zh, ar) {
  return { fr, en, es, de, pt, zh, ar };
}

const footer = L(
  "Cet e-mail a été envoyé par TutorSphere. Ne répondez pas directement à ce message.<br/>© 2026 TutorSphere — <a href=\"https://tutorsphere.gisebs.com\" style=\"color:#5831E0;text-decoration:none;\">tutorsphere.gisebs.com</a>",
  "This email was sent by TutorSphere. Please do not reply directly to this message.<br/>© 2026 TutorSphere — <a href=\"https://tutorsphere.gisebs.com\" style=\"color:#5831E0;text-decoration:none;\">tutorsphere.gisebs.com</a>",
  "Este correo fue enviado por TutorSphere. No responda directamente a este mensaje.<br/>© 2026 TutorSphere — <a href=\"https://tutorsphere.gisebs.com\" style=\"color:#5831E0;text-decoration:none;\">tutorsphere.gisebs.com</a>",
  "Diese E-Mail wurde von TutorSphere gesendet. Bitte antworten Sie nicht direkt auf diese Nachricht.<br/>© 2026 TutorSphere — <a href=\"https://tutorsphere.gisebs.com\" style=\"color:#5831E0;text-decoration:none;\">tutorsphere.gisebs.com</a>",
  "Este e-mail foi enviado pelo TutorSphere. Não responda diretamente a esta mensagem.<br/>© 2026 TutorSphere — <a href=\"https://tutorsphere.gisebs.com\" style=\"color:#5831E0;text-decoration:none;\">tutorsphere.gisebs.com</a>",
  "此邮件由 TutorSphere 发送。请勿直接回复此消息。<br/>© 2026 TutorSphere — <a href=\"https://tutorsphere.gisebs.com\" style=\"color:#5831E0;text-decoration:none;\">tutorsphere.gisebs.com</a>",
  "تم إرسال هذا البريد بواسطة TutorSphere. يُرجى عدم الرد مباشرة على هذه الرسالة.<br/>© 2026 TutorSphere — <a href=\"https://tutorsphere.gisebs.com\" style=\"color:#5831E0;text-decoration:none;\">tutorsphere.gisebs.com</a>"
);

/** Pied de page invitation expert : URL de connexion + écosystème GISEBS */
const expertInviteFooter = L(
  `Connectez-vous uniquement sur l’espace expert :<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(équivalent : <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">Écosystème GISEBS — nos produits</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
Cet e-mail a été envoyé par TutorSphere (GISEBS). Ne répondez pas directement à ce message.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>`,
  `Sign in only on the expert space:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(canonical: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">GISEBS ecosystem — our products</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
This email was sent by TutorSphere (GISEBS). Please do not reply directly.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>`,
  `Inicie sesión solo en el espacio experto:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(canónica: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">Ecosistema GISEBS — nuestros productos</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
Este correo fue enviado por TutorSphere (GISEBS). No responda directamente.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>`,
  `Melden Sie sich nur im Expertenbereich an:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(kanonisch: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">GISEBS-Ökosystem — unsere Produkte</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
Diese E-Mail wurde von TutorSphere (GISEBS) gesendet. Bitte nicht direkt antworten.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>`,
  `Inicie sessão apenas no espaço de especialista:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(canónico: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">Ecossistema GISEBS — os nossos produtos</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
Este e-mail foi enviado pelo TutorSphere (GISEBS). Não responda diretamente.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>`,
  `请仅通过专家空间登录：<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">（标准地址：<a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>）</span>
<br/><br/>
<strong style="color:#333;">GISEBS 生态系统 — 我们的产品</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
此邮件由 TutorSphere（GISEBS）发送。请勿直接回复。<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>`,
  `سجّل الدخول فقط عبر مساحة الخبير:<br/><a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a><br/><span style="color:#666;">(العنوان الرسمي: <a href="https://tutorsphere.gisebs.com/login/expert" style="color:#5831E0;">https://tutorsphere.gisebs.com/login/expert</a>)</span>
<br/><br/>
<strong style="color:#333;">منظومة GISEBS — منتجاتنا</strong><br/>
<a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">GISEBS</a> ·
<a href="https://tutorsphere.gisebs.com" style="color:#5831E0;text-decoration:none;">TutorSphere</a> ·
<a href="https://agentiafactory.gisebs.com/" style="color:#5831E0;text-decoration:none;">Agentia OS</a> ·
<a href="https://cognidoc.gisebs.com/" style="color:#5831E0;text-decoration:none;">CogniDoc</a> ·
<a href="https://giseboutique.gisebs.com/" style="color:#5831E0;text-decoration:none;">GISEBoutique</a> ·
<a href="https://comptadoc.gisebs.com" style="color:#5831E0;text-decoration:none;">ComptaDoc</a> ·
<a href="https://gisebsapipaygateway.gisebs.com" style="color:#5831E0;text-decoration:none;">Pay Gateway</a>
<br/><br/>
تم إرسال هذا البريد بواسطة TutorSphere (GISEBS). يُرجى عدم الرد مباشرة.<br/>© 2026 GISEBS — <a href="https://gisebs.com" style="color:#5831E0;text-decoration:none;">gisebs.com</a>`
);

const ignore = L(
  "Si vous n'avez pas créé de compte, ignorez cet e-mail.",
  "If you did not create an account, please ignore this email.",
  "Si no creó una cuenta, ignore este correo.",
  "Wenn Sie kein Konto erstellt haben, ignorieren Sie diese E-Mail.",
  "Se não criou uma conta, ignore este e-mail.",
  "如果您未创建帐户，请忽略此邮件。",
  "إذا لم تنشئ حسابًا، فتجاهل هذا البريد."
);

const templates = [
  {
    code: "WELCOME",
    name: L("TutorSphere — Bienvenue", "TutorSphere — Welcome", "TutorSphere — Bienvenida", "TutorSphere — Willkommen", "TutorSphere — Boas-vindas", "TutorSphere — 欢迎", "TutorSphere — مرحبًا"),
    subject: L("Bienvenue {{FirstName}} sur TutorSphere !", "Welcome {{FirstName}} to TutorSphere!", "¡Bienvenido/a {{FirstName}} a TutorSphere!", "Willkommen {{FirstName}} bei TutorSphere!", "Bem-vindo(a) {{FirstName}} ao TutorSphere!", "欢迎 {{FirstName}} 加入 TutorSphere！", "مرحبًا {{FirstName}} في TutorSphere!"),
    title: L("Bienvenue {{FirstName}} !", "Welcome {{FirstName}}!", "¡Bienvenido/a {{FirstName}}!", "Willkommen {{FirstName}}!", "Bem-vindo(a) {{FirstName}}!", "欢迎，{{FirstName}}！", "مرحبًا {{FirstName}}!"),
    body: L(
      "Votre compte TutorSphere est prêt. Connectez-vous pour accéder à votre espace personnel.",
      "Your TutorSphere account is ready. Sign in to access your personal space.",
      "Su cuenta de TutorSphere está lista. Inicie sesión para acceder a su espacio personal.",
      "Ihr TutorSphere-Konto ist bereit. Melden Sie sich an, um auf Ihren Bereich zuzugreifen.",
      "A sua conta TutorSphere está pronta. Inicie sessão para aceder ao seu espaço pessoal.",
      "您的 TutorSphere 帐户已准备就绪。请登录以访问您的个人空间。",
      "حساب TutorSphere جاهز. سجّل الدخول للوصول إلى مساحتك الشخصية."
    ),
    btn: L("Accéder à mon espace", "Go to my space", "Ir a mi espacio", "Zu meinem Bereich", "Aceder ao meu espaço", "进入我的空间", "الانتقال إلى مساحتي"),
    btnUrl: "https://tutorsphere.gisebs.com/login",
    text: L("Bienvenue {{FirstName}} sur TutorSphere.", "Welcome {{FirstName}} to TutorSphere.", "Bienvenido/a {{FirstName}} a TutorSphere.", "Willkommen {{FirstName}} bei TutorSphere.", "Bem-vindo(a) {{FirstName}} ao TutorSphere.", "欢迎 {{FirstName}} 加入 TutorSphere。", "مرحبًا {{FirstName}} في TutorSphere.")
  },
  {
    code: "PARENT_CONFIRM_ACCESS",
    name: L("TutorSphere — Validation espace parent", "TutorSphere — Parent space validation", "TutorSphere — Validación espacio padres", "TutorSphere — Elternbereich bestätigen", "TutorSphere — Validação espaço responsável", "TutorSphere — 家长空间验证", "TutorSphere — تأكيد مساحة ولي الأمر"),
    subject: L("Validez votre espace parent — TutorSphere", "Validate your parent space — TutorSphere", "Valide su espacio de padres — TutorSphere", "Bestätigen Sie Ihren Elternbereich — TutorSphere", "Valide o seu espaço de responsável — TutorSphere", "验证您的家长空间 — TutorSphere", "أكد مساحة ولي الأمر — TutorSphere"),
    title: L("Activez votre espace parent", "Activate your parent space", "Active su espacio de padres", "Aktivieren Sie Ihren Elternbereich", "Ative o seu espaço de responsável", "激活您的家长空间", "فعّل مساحة ولي الأمر"),
    hello: true,
    body: L(
      "Bienvenue sur TutorSphere. Pour accéder à <strong>l'espace parent</strong> et suivre le parcours scolaire de vos enfants, veuillez d'abord <strong>valider votre adresse e-mail</strong>. Sans cette validation, la connexion reste bloquée.",
      "Welcome to TutorSphere. To access the <strong>parent space</strong> and follow your children's learning journey, please <strong>validate your email address</strong> first. Without this validation, sign-in remains blocked.",
      "Bienvenido/a a TutorSphere. Para acceder al <strong>espacio de padres</strong> y seguir el recorrido escolar de sus hijos, primero <strong>valide su correo electrónico</strong>. Sin esta validación, el acceso permanece bloqueado.",
      "Willkommen bei TutorSphere. Um den <strong>Elternbereich</strong> zu nutzen und den Lernweg Ihrer Kinder zu verfolgen, bestätigen Sie bitte zuerst Ihre <strong>E-Mail-Adresse</strong>. Ohne Bestätigung bleibt die Anmeldung gesperrt.",
      "Bem-vindo(a) ao TutorSphere. Para aceder ao <strong>espaço de responsável</strong> e acompanhar o percurso escolar dos seus filhos, <strong>valide primeiro o seu e-mail</strong>. Sem esta validação, o acesso permanece bloqueado.",
      "欢迎使用 TutorSphere。要访问<strong>家长空间</strong>并跟进孩子的学习，请先<strong>验证您的电子邮件</strong>。未验证前无法登录。",
      "مرحبًا بك في TutorSphere. للوصول إلى <strong>مساحة ولي الأمر</strong> ومتابعة مسار أبنائك الدراسي، يرجى <strong>تأكيد بريدك الإلكتروني</strong> أولًا. بدون هذا التأكيد يبقى تسجيل الدخول محظورًا."
    ),
    btn: L("Valider mon espace parent", "Validate my parent space", "Validar mi espacio de padres", "Elternbereich bestätigen", "Validar o meu espaço de responsável", "验证我的家长空间", "تأكيد مساحة ولي الأمر"),
    btnUrl: "{{ConfirmationUrl}}",
    footerNote: ignore,
    text: L(
      "Validez votre espace parent TutorSphere : {{ConfirmationUrl}}",
      "Validate your TutorSphere parent space: {{ConfirmationUrl}}",
      "Valide su espacio de padres TutorSphere: {{ConfirmationUrl}}",
      "Bestätigen Sie Ihren TutorSphere-Elternbereich: {{ConfirmationUrl}}",
      "Valide o seu espaço de responsável TutorSphere: {{ConfirmationUrl}}",
      "验证您的 TutorSphere 家长空间：{{ConfirmationUrl}}",
      "أكد مساحة ولي الأمر في TutorSphere: {{ConfirmationUrl}}"
    )
  },
  {
    code: "CONFIRM_EMAIL",
    name: L("TutorSphere — Confirmation e-mail (école)", "TutorSphere — Email confirmation (school)", "TutorSphere — Confirmación de correo (escuela)", "TutorSphere — E-Mail-Bestätigung (Schule)", "TutorSphere — Confirmação de e-mail (escola)", "TutorSphere — 确认电子邮件（学校）", "TutorSphere — تأكيد البريد (مدرسة)"),
    subject: L("Confirmez votre adresse e-mail — TutorSphere", "Confirm your email address — TutorSphere", "Confirme su correo electrónico — TutorSphere", "Bestätigen Sie Ihre E-Mail — TutorSphere", "Confirme o seu e-mail — TutorSphere", "确认您的电子邮件 — TutorSphere", "أكد عنوان بريدك — TutorSphere"),
    title: L("Confirmez votre adresse e-mail", "Confirm your email address", "Confirme su correo electrónico", "Bestätigen Sie Ihre E-Mail-Adresse", "Confirme o seu endereço de e-mail", "确认您的电子邮件地址", "أكد عنوان بريدك الإلكتروني"),
    hello: true,
    body: L(
      "Cliquez sur le bouton ci-dessous pour activer votre compte école.",
      "Click the button below to activate your school account.",
      "Haga clic en el botón de abajo para activar su cuenta de escuela.",
      "Klicken Sie auf die Schaltfläche unten, um Ihr Schulkonto zu aktivieren.",
      "Clique no botão abaixo para ativar a sua conta de escola.",
      "点击下方按钮以激活您的学校帐户。",
      "انقر على الزر أدناه لتفعيل حساب مدرستك."
    ),
    btn: L("Confirmer mon e-mail", "Confirm my email", "Confirmar mi correo", "E-Mail bestätigen", "Confirmar o meu e-mail", "确认我的电子邮件", "تأكيد بريدي"),
    btnUrl: "{{ConfirmationUrl}}",
    footerNote: ignore,
    text: L("Confirmez votre e-mail : {{ConfirmationUrl}}", "Confirm your email: {{ConfirmationUrl}}", "Confirme su correo: {{ConfirmationUrl}}", "Bestätigen Sie Ihre E-Mail: {{ConfirmationUrl}}", "Confirme o seu e-mail: {{ConfirmationUrl}}", "确认您的电子邮件：{{ConfirmationUrl}}", "أكد بريدك: {{ConfirmationUrl}}")
  },
  {
    code: "LESSON_REPORT",
    name: L("TutorSphere — Rapport de cours au parent", "TutorSphere — Lesson report to parent", "TutorSphere — Informe de clase al padre", "TutorSphere — Unterrichtsbericht an Eltern", "TutorSphere — Relatório de aula ao responsável", "TutorSphere — 课程报告（家长）", "TutorSphere — تقرير الحصة لولي الأمر"),
    subject: L("Rapport de cours pour {{StudentName}} — TutorSphere", "Lesson report for {{StudentName}} — TutorSphere", "Informe de clase de {{StudentName}} — TutorSphere", "Unterrichtsbericht für {{StudentName}} — TutorSphere", "Relatório de aula de {{StudentName}} — TutorSphere", "{{StudentName}} 的课程报告 — TutorSphere", "تقرير الحصة لـ {{StudentName}} — TutorSphere"),
    title: L("Rapport de cours", "Lesson report", "Informe de clase", "Unterrichtsbericht", "Relatório de aula", "课程报告", "تقرير الحصة"),
    helloParent: true,
    body: L(
      "Voici le rapport de la dernière séance de <strong>{{StudentName}}</strong> avec <strong>{{TutorName}}</strong>.",
      "Here is the report from <strong>{{StudentName}}</strong>'s latest session with <strong>{{TutorName}}</strong>.",
      "Aquí tiene el informe de la última sesión de <strong>{{StudentName}}</strong> con <strong>{{TutorName}}</strong>.",
      "Hier ist der Bericht der letzten Sitzung von <strong>{{StudentName}}</strong> mit <strong>{{TutorName}}</strong>.",
      "Segue o relatório da última sessão de <strong>{{StudentName}}</strong> com <strong>{{TutorName}}</strong>.",
      "以下是 <strong>{{StudentName}}</strong> 与 <strong>{{TutorName}}</strong> 最近一次课程的报告。",
      "إليك تقرير آخر حصة لـ <strong>{{StudentName}}</strong> مع <strong>{{TutorName}}</strong>."
    ),
    note: L(
      "Connectez-vous à votre espace pour consulter le rapport complet.",
      "Sign in to your space to view the full report.",
      "Inicie sesión en su espacio para ver el informe completo.",
      "Melden Sie sich an, um den vollständigen Bericht anzuzeigen.",
      "Inicie sessão no seu espaço para ver o relatório completo.",
      "登录您的空间以查看完整报告。",
      "سجّل الدخول إلى مساحتك لعرض التقرير الكامل."
    ),
    btn: L("Voir le rapport", "View report", "Ver informe", "Bericht ansehen", "Ver relatório", "查看报告", "عرض التقرير"),
    btnUrl: "https://tutorsphere.gisebs.com/login",
    text: L("Rapport de cours pour {{StudentName}} avec {{TutorName}}.", "Lesson report for {{StudentName}} with {{TutorName}}.", "Informe de clase de {{StudentName}} con {{TutorName}}.", "Unterrichtsbericht für {{StudentName}} mit {{TutorName}}.", "Relatório de aula de {{StudentName}} com {{TutorName}}.", "{{StudentName}} 与 {{TutorName}} 的课程报告。", "تقرير الحصة لـ {{StudentName}} مع {{TutorName}}.")
  },
  {
    code: "SCHOOL_CREATED",
    name: L("TutorSphere — École créée (en attente)", "TutorSphere — School created (pending)", "TutorSphere — Escuela creada (pendiente)", "TutorSphere — Schule erstellt (ausstehend)", "TutorSphere — Escola criada (pendente)", "TutorSphere — 学校已创建（待审）", "TutorSphere — تم إنشاء المدرسة (قيد الانتظار)"),
    subject: L("Votre école {{SchoolName}} est en cours de validation — TutorSphere", "Your school {{SchoolName}} is being reviewed — TutorSphere", "Su escuela {{SchoolName}} está en revisión — TutorSphere", "Ihre Schule {{SchoolName}} wird geprüft — TutorSphere", "A sua escola {{SchoolName}} está em análise — TutorSphere", "您的学校 {{SchoolName}} 正在审核 — TutorSphere", "مدرستك {{SchoolName}} قيد المراجعة — TutorSphere"),
    title: L("École enregistrée", "School registered", "Escuela registrada", "Schule registriert", "Escola registada", "学校已登记", "تم تسجيل المدرسة"),
    helloOwner: true,
    body: L(
      "Votre école <strong>{{SchoolName}}</strong> a bien été enregistrée et est en attente de validation par l'équipe TutorSphere.",
      "Your school <strong>{{SchoolName}}</strong> has been registered and is awaiting approval by the TutorSphere team.",
      "Su escuela <strong>{{SchoolName}}</strong> ha sido registrada y está pendiente de aprobación por el equipo de TutorSphere.",
      "Ihre Schule <strong>{{SchoolName}}</strong> wurde registriert und wartet auf die Freigabe durch das TutorSphere-Team.",
      "A sua escola <strong>{{SchoolName}}</strong> foi registada e aguarda aprovação da equipa TutorSphere.",
      "您的学校 <strong>{{SchoolName}}</strong> 已登记，正在等待 TutorSphere 团队审核。",
      "تم تسجيل مدرستك <strong>{{SchoolName}}</strong> وهي بانتظار موافقة فريق TutorSphere."
    ),
    body2: L(
      "Vous serez notifié par e-mail dès qu'une décision sera prise (délai habituel : 1 à 2 jours ouvrables).",
      "You will be notified by email once a decision is made (usually 1–2 business days).",
      "Se le notificará por correo cuando se tome una decisión (plazo habitual: 1 a 2 días hábiles).",
      "Sie werden per E-Mail benachrichtigt, sobald eine Entscheidung vorliegt (in der Regel 1–2 Werktage).",
      "Será notificado por e-mail assim que houver uma decisão (prazo habitual: 1 a 2 dias úteis).",
      "作出决定后将通过电子邮件通知您（通常为 1–2 个工作日）。",
      "سيتم إعلامك بالبريد عند اتخاذ قرار (عادة خلال يوم إلى يومي عمل)."
    ),
    text: L("École {{SchoolName}} enregistrée, en attente de validation.", "School {{SchoolName}} registered, awaiting approval.", "Escuela {{SchoolName}} registrada, pendiente de aprobación.", "Schule {{SchoolName}} registriert, Freigabe ausstehend.", "Escola {{SchoolName}} registada, aguarda aprovação.", "学校 {{SchoolName}} 已登记，等待审核。", "تم تسجيل المدرسة {{SchoolName}} وبانتظار الموافقة.")
  },
  {
    code: "CONFIRM_EMAIL_SIMPLE",
    name: L("TutorSphere — Confirmation e-mail (standard)", "TutorSphere — Email confirmation (standard)", "TutorSphere — Confirmación de correo (estándar)", "TutorSphere — E-Mail-Bestätigung (Standard)", "TutorSphere — Confirmação de e-mail (padrão)", "TutorSphere — 确认电子邮件（标准）", "TutorSphere — تأكيد البريد (قياسي)"),
    subject: L("Confirmez votre adresse e-mail — TutorSphere", "Confirm your email address — TutorSphere", "Confirme su correo electrónico — TutorSphere", "Bestätigen Sie Ihre E-Mail — TutorSphere", "Confirme o seu e-mail — TutorSphere", "确认您的电子邮件 — TutorSphere", "أكد عنوان بريدك — TutorSphere"),
    title: L("Confirmez votre adresse e-mail", "Confirm your email address", "Confirme su correo electrónico", "Bestätigen Sie Ihre E-Mail-Adresse", "Confirme o seu endereço de e-mail", "确认您的电子邮件地址", "أكد عنوان بريدك الإلكتروني"),
    hello: true,
    body: L(
      "Merci de confirmer votre adresse e-mail pour finaliser la création de votre compte.",
      "Please confirm your email address to finish creating your account.",
      "Confirme su correo electrónico para finalizar la creación de su cuenta.",
      "Bitte bestätigen Sie Ihre E-Mail-Adresse, um die Kontoerstellung abzuschließen.",
      "Confirme o seu e-mail para concluir a criação da sua conta.",
      "请确认您的电子邮件地址以完成帐户创建。",
      "يرجى تأكيد بريدك الإلكتروني لإكمال إنشاء حسابك."
    ),
    btn: L("Confirmer mon e-mail", "Confirm my email", "Confirmar mi correo", "E-Mail bestätigen", "Confirmar o meu e-mail", "确认我的电子邮件", "تأكيد بريدي"),
    btnUrl: "{{ConfirmationUrl}}",
    footerNote: ignore,
    text: L("Confirmez votre e-mail : {{ConfirmationUrl}}", "Confirm your email: {{ConfirmationUrl}}", "Confirme su correo: {{ConfirmationUrl}}", "Bestätigen Sie Ihre E-Mail: {{ConfirmationUrl}}", "Confirme o seu e-mail: {{ConfirmationUrl}}", "确认您的电子邮件：{{ConfirmationUrl}}", "أكد بريدك: {{ConfirmationUrl}}")
  },
  {
    code: "RESET_PASSWORD",
    name: L("TutorSphere — Réinitialisation mot de passe", "TutorSphere — Password reset", "TutorSphere — Restablecer contraseña", "TutorSphere — Passwort zurücksetzen", "TutorSphere — Redefinição de palavra-passe", "TutorSphere — 重置密码", "TutorSphere — إعادة تعيين كلمة المرور"),
    subject: L("Réinitialisez votre mot de passe — TutorSphere", "Reset your password — TutorSphere", "Restablezca su contraseña — TutorSphere", "Setzen Sie Ihr Passwort zurück — TutorSphere", "Redefina a sua palavra-passe — TutorSphere", "重置您的密码 — TutorSphere", "أعد تعيين كلمة المرور — TutorSphere"),
    title: L("Réinitialisation du mot de passe", "Password reset", "Restablecer contraseña", "Passwort zurücksetzen", "Redefinição de palavra-passe", "重置密码", "إعادة تعيين كلمة المرور"),
    hello: true,
    body: L(
      "Vous avez demandé à réinitialiser votre mot de passe TutorSphere. Cliquez ci-dessous :",
      "You requested to reset your TutorSphere password. Click below:",
      "Solicitó restablecer su contraseña de TutorSphere. Haga clic abajo:",
      "Sie haben das Zurücksetzen Ihres TutorSphere-Passworts angefordert. Klicken Sie unten:",
      "Pediu para redefinir a sua palavra-passe TutorSphere. Clique abaixo:",
      "您请求重置 TutorSphere 密码。请点击下方：",
      "طلبت إعادة تعيين كلمة مرور TutorSphere. انقر أدناه:"
    ),
    btn: L("Réinitialiser mon mot de passe", "Reset my password", "Restablecer mi contraseña", "Passwort zurücksetzen", "Redefinir a minha palavra-passe", "重置我的密码", "إعادة تعيين كلمة المرور"),
    btnUrl: "{{ResetUrl}}",
    footerNote: L(
      "Ce lien est valide 24 heures. Si vous n'avez pas fait cette demande, ignorez cet e-mail.",
      "This link is valid for 24 hours. If you did not request this, ignore this email.",
      "Este enlace es válido 24 horas. Si no lo solicitó, ignore este correo.",
      "Dieser Link ist 24 Stunden gültig. Wenn Sie dies nicht angefordert haben, ignorieren Sie diese E-Mail.",
      "Este link é válido por 24 horas. Se não fez este pedido, ignore este e-mail.",
      "此链接 24 小时内有效。如非您本人操作，请忽略此邮件。",
      "هذا الرابط صالح لمدة 24 ساعة. إذا لم تطلب ذلك، فتجاهل هذا البريد."
    ),
    text: L("Réinitialisez votre mot de passe : {{ResetUrl}}", "Reset your password: {{ResetUrl}}", "Restablezca su contraseña: {{ResetUrl}}", "Passwort zurücksetzen: {{ResetUrl}}", "Redefina a sua palavra-passe: {{ResetUrl}}", "重置密码：{{ResetUrl}}", "أعد تعيين كلمة المرور: {{ResetUrl}}")
  },
  {
    code: "PASSWORD_CHANGED",
    name: L("TutorSphere — Mot de passe modifié", "TutorSphere — Password changed", "TutorSphere — Contraseña cambiada", "TutorSphere — Passwort geändert", "TutorSphere — Palavra-passe alterada", "TutorSphere — 密码已更改", "TutorSphere — تم تغيير كلمة المرور"),
    subject: L("Votre mot de passe a été modifié — TutorSphere", "Your password was changed — TutorSphere", "Su contraseña fue cambiada — TutorSphere", "Ihr Passwort wurde geändert — TutorSphere", "A sua palavra-passe foi alterada — TutorSphere", "您的密码已更改 — TutorSphere", "تم تغيير كلمة مرورك — TutorSphere"),
    title: L("Mot de passe modifié", "Password changed", "Contraseña cambiada", "Passwort geändert", "Palavra-passe alterada", "密码已更改", "تم تغيير كلمة المرور"),
    hello: true,
    body: L(
      "Votre mot de passe TutorSphere a bien été modifié.",
      "Your TutorSphere password has been changed.",
      "Su contraseña de TutorSphere ha sido cambiada.",
      "Ihr TutorSphere-Passwort wurde geändert.",
      "A sua palavra-passe TutorSphere foi alterada.",
      "您的 TutorSphere 密码已更改。",
      "تم تغيير كلمة مرور TutorSphere الخاصة بك."
    ),
    body2: L(
      "Si vous n'êtes pas à l'origine de cette modification, contactez immédiatement le support.",
      "If you did not make this change, contact support immediately.",
      "Si no realizó este cambio, contacte al soporte de inmediato.",
      "Wenn Sie diese Änderung nicht vorgenommen haben, kontaktieren Sie sofort den Support.",
      "Se não fez esta alteração, contacte o suporte imediatamente.",
      "如非您本人操作，请立即联系支持。",
      "إذا لم تقم بهذا التغيير، فاتصل بالدعم فورًا."
    ),
    btn: L("Se connecter", "Sign in", "Iniciar sesión", "Anmelden", "Iniciar sessão", "登录", "تسجيل الدخول"),
    btnUrl: "https://tutorsphere.gisebs.com/login",
    text: L("Bonjour {{FirstName}}, votre mot de passe TutorSphere a été modifié.", "Hi {{FirstName}}, your TutorSphere password was changed.", "Hola {{FirstName}}, su contraseña de TutorSphere fue cambiada.", "Hallo {{FirstName}}, Ihr TutorSphere-Passwort wurde geändert.", "Olá {{FirstName}}, a sua palavra-passe TutorSphere foi alterada.", "{{FirstName}}，您好，您的 TutorSphere 密码已更改。", "مرحبًا {{FirstName}}، تم تغيير كلمة مرور TutorSphere.")
  },
  {
    code: "TUTOR_TRIAL_STARTED",
    name: L("TutorSphere — Essai gratuit tuteur démarré", "TutorSphere — Tutor free trial started", "TutorSphere — Prueba gratuita de tutor iniciada", "TutorSphere — Tutor-Testversion gestartet", "TutorSphere — Avaliação gratuita do tutor iniciada", "TutorSphere — 导师免费试用已开始", "TutorSphere — بدأت الفترة التجريبية للمعلم"),
    subject: L("Votre essai gratuit TutorSphere a commencé !", "Your TutorSphere free trial has started!", "¡Su prueba gratuita de TutorSphere ha comenzado!", "Ihre TutorSphere-Testversion hat begonnen!", "A sua avaliação gratuita TutorSphere começou!", "您的 TutorSphere 免费试用已开始！", "بدأت فترتك التجريبية في TutorSphere!"),
    title: L("Votre essai gratuit a commencé !", "Your free trial has started!", "¡Su prueba gratuita ha comenzado!", "Ihre Testversion hat begonnen!", "A sua avaliação gratuita começou!", "您的免费试用已开始！", "بدأت فترتك التجريبية!"),
    hello: true,
    body: L(
      "Bienvenue dans TutorSphere ! Votre période d'essai gratuit est maintenant active.",
      "Welcome to TutorSphere! Your free trial period is now active.",
      "¡Bienvenido/a a TutorSphere! Su período de prueba gratuita ya está activo.",
      "Willkommen bei TutorSphere! Ihre kostenlose Testphase ist jetzt aktiv.",
      "Bem-vindo(a) ao TutorSphere! O seu período de avaliação gratuita está ativo.",
      "欢迎使用 TutorSphere！您的免费试用期现已激活。",
      "مرحبًا بك في TutorSphere! فترتك التجريبية المجانية نشطة الآن."
    ),
    body2: L(
      "Profitez de toutes les fonctionnalités pour gérer vos cours, vos élèves et vos paiements.",
      "Enjoy all features to manage your lessons, students, and payments.",
      "Disfrute de todas las funciones para gestionar sus clases, alumnos y pagos.",
      "Nutzen Sie alle Funktionen zur Verwaltung von Unterricht, Schülern und Zahlungen.",
      "Aproveite todas as funcionalidades para gerir aulas, alunos e pagamentos.",
      "畅享全部功能，管理课程、学生和付款。",
      "استفد من جميع الميزات لإدارة دروسك وطلابك ومدفوعاتك."
    ),
    btn: L("Accéder à mon tableau de bord", "Go to my dashboard", "Ir a mi panel", "Zum Dashboard", "Ir ao meu painel", "前往我的仪表板", "الانتقال إلى لوحة التحكم"),
    btnUrl: "https://tutorsphere.gisebs.com/dashboard",
    text: L("Bonjour {{FirstName}}, votre essai gratuit TutorSphere a commencé.", "Hi {{FirstName}}, your TutorSphere free trial has started.", "Hola {{FirstName}}, su prueba gratuita de TutorSphere ha comenzado.", "Hallo {{FirstName}}, Ihre TutorSphere-Testversion hat begonnen.", "Olá {{FirstName}}, a sua avaliação gratuita TutorSphere começou.", "{{FirstName}}，您好，您的 TutorSphere 免费试用已开始。", "مرحبًا {{FirstName}}، بدأت فترتك التجريبية في TutorSphere.")
  },
  {
    code: "TUTOR_PAYMENT_RECEIPT",
    name: L("TutorSphere — Reçu de paiement tuteur", "TutorSphere — Tutor payment receipt", "TutorSphere — Recibo de pago del tutor", "TutorSphere — Tutor-Zahlungsbeleg", "TutorSphere — Recibo de pagamento do tutor", "TutorSphere — 导师付款收据", "TutorSphere — إيصال دفع المعلم"),
    subject: L("Reçu de paiement — TutorSphere", "Payment receipt — TutorSphere", "Recibo de pago — TutorSphere", "Zahlungsbeleg — TutorSphere", "Recibo de pagamento — TutorSphere", "付款收据 — TutorSphere", "إيصال الدفع — TutorSphere"),
    title: L("Reçu de paiement", "Payment receipt", "Recibo de pago", "Zahlungsbeleg", "Recibo de pagamento", "付款收据", "إيصال الدفع"),
    hello: true,
    body: L(
      "Nous avons bien reçu votre paiement pour votre abonnement TutorSphere.",
      "We have received your payment for your TutorSphere subscription.",
      "Hemos recibido su pago por la suscripción a TutorSphere.",
      "Wir haben Ihre Zahlung für Ihr TutorSphere-Abonnement erhalten.",
      "Recebemos o seu pagamento da subscrição TutorSphere.",
      "我们已收到您的 TutorSphere 订阅付款。",
      "استلمنا دفعتك لاشتراك TutorSphere."
    ),
    amountLabel: L("Montant", "Amount", "Importe", "Betrag", "Montante", "金额", "المبلغ"),
    btn: L("Voir ma facture", "View my invoice", "Ver mi factura", "Rechnung ansehen", "Ver a minha fatura", "查看我的发票", "عرض فاتورتي"),
    btnUrl: "{{InvoiceUrl}}",
    text: L("Reçu de paiement {{Amount}}. Facture : {{InvoiceUrl}}", "Payment receipt {{Amount}}. Invoice: {{InvoiceUrl}}", "Recibo de pago {{Amount}}. Factura: {{InvoiceUrl}}", "Zahlungsbeleg {{Amount}}. Rechnung: {{InvoiceUrl}}", "Recibo de pagamento {{Amount}}. Fatura: {{InvoiceUrl}}", "付款收据 {{Amount}}。发票：{{InvoiceUrl}}", "إيصال دفع {{Amount}}. الفاتورة: {{InvoiceUrl}}")
  },
  {
    code: "TUTOR_RENEWAL_REMINDER",
    name: L("TutorSphere — Rappel de renouvellement tuteur", "TutorSphere — Tutor renewal reminder", "TutorSphere — Recordatorio de renovación del tutor", "TutorSphere — Tutor-Verlängerungserinnerung", "TutorSphere — Lembrete de renovação do tutor", "TutorSphere — 导师续订提醒", "TutorSphere — تذكير بتجديد المعلم"),
    subject: L("Votre abonnement TutorSphere se renouvelle bientôt", "Your TutorSphere subscription renews soon", "Su suscripción a TutorSphere se renueva pronto", "Ihr TutorSphere-Abonnement wird bald verlängert", "A sua subscrição TutorSphere renova em breve", "您的 TutorSphere 订阅即将续订", "سيُجدَّد اشتراكك في TutorSphere قريبًا"),
    title: L("Renouvellement à venir", "Upcoming renewal", "Renovación próxima", "Bevorstehende Verlängerung", "Renovação próxima", "即将续订", "تجديد قادم"),
    hello: true,
    body: L(
      "Votre abonnement TutorSphere se renouvellera le <strong>{{RenewalDate}}</strong>.",
      "Your TutorSphere subscription will renew on <strong>{{RenewalDate}}</strong>.",
      "Su suscripción a TutorSphere se renovará el <strong>{{RenewalDate}}</strong>.",
      "Ihr TutorSphere-Abonnement wird am <strong>{{RenewalDate}}</strong> verlängert.",
      "A sua subscrição TutorSphere será renovada em <strong>{{RenewalDate}}</strong>.",
      "您的 TutorSphere 订阅将于 <strong>{{RenewalDate}}</strong> 续订。",
      "سيُجدَّد اشتراكك في TutorSphere في <strong>{{RenewalDate}}</strong>."
    ),
    body2: L(
      "Assurez-vous que vos informations de paiement sont à jour.",
      "Please make sure your payment details are up to date.",
      "Asegúrese de que sus datos de pago estén actualizados.",
      "Stellen Sie sicher, dass Ihre Zahlungsdaten aktuell sind.",
      "Certifique-se de que os seus dados de pagamento estão atualizados.",
      "请确保您的付款信息是最新的。",
      "تأكد من أن بيانات الدفع محدثة."
    ),
    btn: L("Gérer mon abonnement", "Manage my subscription", "Gestionar mi suscripción", "Abonnement verwalten", "Gerir a minha subscrição", "管理我的订阅", "إدارة اشتراكي"),
    btnUrl: "https://tutorsphere.gisebs.com/settings/billing",
    text: L("Votre abonnement TutorSphere se renouvelle le {{RenewalDate}}.", "Your TutorSphere subscription renews on {{RenewalDate}}.", "Su suscripción a TutorSphere se renueva el {{RenewalDate}}.", "Ihr TutorSphere-Abonnement wird am {{RenewalDate}} verlängert.", "A sua subscrição TutorSphere renova em {{RenewalDate}}.", "您的 TutorSphere 订阅将于 {{RenewalDate}} 续订。", "سيُجدَّد اشتراكك في TutorSphere في {{RenewalDate}}.")
  },
  {
    code: "TUTOR_PAYMENT_FAILED",
    name: L("TutorSphere — Échec de paiement tuteur", "TutorSphere — Tutor payment failed", "TutorSphere — Fallo de pago del tutor", "TutorSphere — Tutor-Zahlung fehlgeschlagen", "TutorSphere — Falha no pagamento do tutor", "TutorSphere — 导师付款失败", "TutorSphere — فشل دفع المعلم"),
    subject: L("Problème de paiement — votre abonnement TutorSphere", "Payment issue — your TutorSphere subscription", "Problema de pago — su suscripción a TutorSphere", "Zahlungsproblem — Ihr TutorSphere-Abonnement", "Problema de pagamento — a sua subscrição TutorSphere", "付款问题 — 您的 TutorSphere 订阅", "مشكلة في الدفع — اشتراك TutorSphere"),
    title: L("Problème de paiement", "Payment issue", "Problema de pago", "Zahlungsproblem", "Problema de pagamento", "付款问题", "مشكلة في الدفع"),
    titleColor: "#dc2626",
    hello: true,
    body: L(
      "Nous n'avons pas pu traiter votre paiement pour votre abonnement TutorSphere.",
      "We could not process your payment for your TutorSphere subscription.",
      "No pudimos procesar su pago de la suscripción a TutorSphere.",
      "Wir konnten Ihre Zahlung für das TutorSphere-Abonnement nicht verarbeiten.",
      "Não foi possível processar o pagamento da sua subscrição TutorSphere.",
      "我们无法处理您的 TutorSphere 订阅付款。",
      "تعذّر معالجة دفعتك لاشتراك TutorSphere."
    ),
    body2: L(
      "Veuillez mettre à jour vos informations de paiement pour éviter l'interruption de votre service.",
      "Please update your payment details to avoid service interruption.",
      "Actualice sus datos de pago para evitar la interrupción del servicio.",
      "Bitte aktualisieren Sie Ihre Zahlungsdaten, um eine Unterbrechung zu vermeiden.",
      "Atualize os seus dados de pagamento para evitar a interrupção do serviço.",
      "请更新付款信息，以免服务中断。",
      "يرجى تحديث بيانات الدفع لتجنب انقطاع الخدمة."
    ),
    btn: L("Mettre à jour mes informations", "Update my details", "Actualizar mis datos", "Daten aktualisieren", "Atualizar os meus dados", "更新我的信息", "تحديث بياناتي"),
    btnUrl: "https://tutorsphere.gisebs.com/settings/billing",
    text: L("Bonjour {{FirstName}}, votre paiement TutorSphere a échoué. Mettez vos informations à jour.", "Hi {{FirstName}}, your TutorSphere payment failed. Please update your details.", "Hola {{FirstName}}, falló su pago de TutorSphere. Actualice sus datos.", "Hallo {{FirstName}}, Ihre TutorSphere-Zahlung ist fehlgeschlagen. Bitte aktualisieren Sie Ihre Daten.", "Olá {{FirstName}}, o pagamento TutorSphere falhou. Atualize os seus dados.", "{{FirstName}}，您好，您的 TutorSphere 付款失败。请更新信息。", "مرحبًا {{FirstName}}، فشل دفع TutorSphere. حدّث بياناتك.")
  },
  {
    code: "TUTOR_SUB_CANCELLED",
    name: L("TutorSphere — Abonnement tuteur annulé", "TutorSphere — Tutor subscription cancelled", "TutorSphere — Suscripción de tutor cancelada", "TutorSphere — Tutor-Abonnement gekündigt", "TutorSphere — Subscrição do tutor cancelada", "TutorSphere — 导师订阅已取消", "TutorSphere — تم إلغاء اشتراك المعلم"),
    subject: L("Votre abonnement TutorSphere a été annulé", "Your TutorSphere subscription was cancelled", "Su suscripción a TutorSphere fue cancelada", "Ihr TutorSphere-Abonnement wurde gekündigt", "A sua subscrição TutorSphere foi cancelada", "您的 TutorSphere 订阅已取消", "تم إلغاء اشتراكك في TutorSphere"),
    title: L("Abonnement annulé", "Subscription cancelled", "Suscripción cancelada", "Abonnement gekündigt", "Subscrição cancelada", "订阅已取消", "تم إلغاء الاشتراك"),
    hello: true,
    body: L(
      "Votre abonnement TutorSphere a bien été annulé. Vous conservez l'accès jusqu'à la fin de la période en cours.",
      "Your TutorSphere subscription has been cancelled. You keep access until the end of the current period.",
      "Su suscripción a TutorSphere ha sido cancelada. Conserva el acceso hasta el final del período actual.",
      "Ihr TutorSphere-Abonnement wurde gekündigt. Sie behalten den Zugang bis zum Ende des aktuellen Zeitraums.",
      "A sua subscrição TutorSphere foi cancelada. Mantém o acesso até ao fim do período atual.",
      "您的 TutorSphere 订阅已取消。在当前周期结束前您仍可访问。",
      "تم إلغاء اشتراكك في TutorSphere. تحتفظ بالوصول حتى نهاية الفترة الحالية."
    ),
    body2: L("Nous espérons vous revoir bientôt !", "We hope to see you again soon!", "¡Esperamos verle pronto de nuevo!", "Wir hoffen, Sie bald wiederzusehen!", "Esperamos vê-lo(a) em breve!", "期待很快再次见到您！", "نأمل أن نراك قريبًا مجددًا!"),
    btn: L("Revenir sur TutorSphere", "Return to TutorSphere", "Volver a TutorSphere", "Zurück zu TutorSphere", "Voltar ao TutorSphere", "返回 TutorSphere", "العودة إلى TutorSphere"),
    btnUrl: "https://tutorsphere.gisebs.com",
    text: L("Bonjour {{FirstName}}, votre abonnement TutorSphere a été annulé.", "Hi {{FirstName}}, your TutorSphere subscription was cancelled.", "Hola {{FirstName}}, su suscripción a TutorSphere fue cancelada.", "Hallo {{FirstName}}, Ihr TutorSphere-Abonnement wurde gekündigt.", "Olá {{FirstName}}, a sua subscrição TutorSphere foi cancelada.", "{{FirstName}}，您好，您的 TutorSphere 订阅已取消。", "مرحبًا {{FirstName}}، تم إلغاء اشتراكك في TutorSphere.")
  },
  {
    code: "ACCOUNT_ACTIVATED",
    name: L("TutorSphere — Compte activé", "TutorSphere — Account activated", "TutorSphere — Cuenta activada", "TutorSphere — Konto aktiviert", "TutorSphere — Conta ativada", "TutorSphere — 帐户已激活", "TutorSphere — تم تفعيل الحساب"),
    subject: L("Votre compte TutorSphere a été activé", "Your TutorSphere account was activated", "Su cuenta de TutorSphere fue activada", "Ihr TutorSphere-Konto wurde aktiviert", "A sua conta TutorSphere foi ativada", "您的 TutorSphere 帐户已激活", "تم تفعيل حسابك في TutorSphere"),
    title: L("Compte activé", "Account activated", "Cuenta activada", "Konto aktiviert", "Conta ativada", "帐户已激活", "تم تفعيل الحساب"),
    titleColor: "#16a34a",
    hello: true,
    body: L(
      "Votre compte TutorSphere a été <strong>activé</strong>. Vous pouvez désormais vous connecter normalement.",
      "Your TutorSphere account has been <strong>activated</strong>. You can now sign in normally.",
      "Su cuenta de TutorSphere ha sido <strong>activada</strong>. Ya puede iniciar sesión con normalidad.",
      "Ihr TutorSphere-Konto wurde <strong>aktiviert</strong>. Sie können sich jetzt normal anmelden.",
      "A sua conta TutorSphere foi <strong>ativada</strong>. Já pode iniciar sessão normalmente.",
      "您的 TutorSphere 帐户已<strong>激活</strong>。您现在可以正常登录。",
      "تم <strong>تفعيل</strong> حساب TutorSphere. يمكنك الآن تسجيل الدخول كالمعتاد."
    ),
    btn: L("Se connecter", "Sign in", "Iniciar sesión", "Anmelden", "Iniciar sessão", "登录", "تسجيل الدخول"),
    btnUrl: "https://tutorsphere.gisebs.com/login",
    text: L("Bonjour {{FirstName}}, votre compte TutorSphere a été activé.", "Hi {{FirstName}}, your TutorSphere account was activated.", "Hola {{FirstName}}, su cuenta de TutorSphere fue activada.", "Hallo {{FirstName}}, Ihr TutorSphere-Konto wurde aktiviert.", "Olá {{FirstName}}, a sua conta TutorSphere foi ativada.", "{{FirstName}}，您好，您的 TutorSphere 帐户已激活。", "مرحبًا {{FirstName}}، تم تفعيل حسابك في TutorSphere.")
  },
  {
    code: "ACCOUNT_DEACTIVATED",
    name: L("TutorSphere — Compte désactivé", "TutorSphere — Account deactivated", "TutorSphere — Cuenta desactivada", "TutorSphere — Konto deaktiviert", "TutorSphere — Conta desativada", "TutorSphere — 帐户已停用", "TutorSphere — تم تعطيل الحساب"),
    subject: L("Votre compte TutorSphere a été désactivé", "Your TutorSphere account was deactivated", "Su cuenta de TutorSphere fue desactivada", "Ihr TutorSphere-Konto wurde deaktiviert", "A sua conta TutorSphere foi desativada", "您的 TutorSphere 帐户已停用", "تم تعطيل حسابك في TutorSphere"),
    title: L("Compte désactivé", "Account deactivated", "Cuenta desactivada", "Konto deaktiviert", "Conta desativada", "帐户已停用", "تم تعطيل الحساب"),
    titleColor: "#dc2626",
    hello: true,
    body: L(
      "Votre compte TutorSphere a été désactivé par l'administration.",
      "Your TutorSphere account was deactivated by administration.",
      "Su cuenta de TutorSphere fue desactivada por la administración.",
      "Ihr TutorSphere-Konto wurde von der Administration deaktiviert.",
      "A sua conta TutorSphere foi desativada pela administração.",
      "您的 TutorSphere 帐户已被管理员停用。",
      "تم تعطيل حساب TutorSphere من قبل الإدارة."
    ),
    reasonLabel: L("Motif", "Reason", "Motivo", "Grund", "Motivo", "原因", "السبب"),
    footerNote: L(
      "Pour toute question, contactez le support TutorSphere.",
      "For any questions, contact TutorSphere support.",
      "Para cualquier pregunta, contacte al soporte de TutorSphere.",
      "Bei Fragen wenden Sie sich an den TutorSphere-Support.",
      "Para qualquer questão, contacte o suporte TutorSphere.",
      "如有疑问，请联系 TutorSphere 支持。",
      "لأي استفسار، تواصل مع دعم TutorSphere."
    ),
    text: L("Bonjour {{FirstName}}, votre compte a été désactivé. Motif : {{Reason}}", "Hi {{FirstName}}, your account was deactivated. Reason: {{Reason}}", "Hola {{FirstName}}, su cuenta fue desactivada. Motivo: {{Reason}}", "Hallo {{FirstName}}, Ihr Konto wurde deaktiviert. Grund: {{Reason}}", "Olá {{FirstName}}, a sua conta foi desativada. Motivo: {{Reason}}", "{{FirstName}}，您好，您的帐户已停用。原因：{{Reason}}", "مرحبًا {{FirstName}}، تم تعطيل حسابك. السبب: {{Reason}}")
  },
  {
    code: "SCHOOL_APPROVED",
    name: L("TutorSphere — École approuvée", "TutorSphere — School approved", "TutorSphere — Escuela aprobada", "TutorSphere — Schule genehmigt", "TutorSphere — Escola aprovada", "TutorSphere — 学校已批准", "TutorSphere — تمت الموافقة على المدرسة"),
    subject: L("Félicitations ! Votre école {{SchoolName}} est approuvée", "Congratulations! Your school {{SchoolName}} is approved", "¡Enhorabuena! Su escuela {{SchoolName}} está aprobada", "Glückwunsch! Ihre Schule {{SchoolName}} ist genehmigt", "Parabéns! A sua escola {{SchoolName}} foi aprovada", "恭喜！您的学校 {{SchoolName}} 已获批准", "تهانينا! تمت الموافقة على مدرستك {{SchoolName}}"),
    title: L("École approuvée !", "School approved!", "¡Escuela aprobada!", "Schule genehmigt!", "Escola aprovada!", "学校已批准！", "تمت الموافقة على المدرسة!"),
    titleColor: "#16a34a",
    hello: true,
    body: L(
      "Bonne nouvelle : votre école <strong>{{SchoolName}}</strong> a été <strong>approuvée</strong> par l'équipe TutorSphere.",
      "Good news: your school <strong>{{SchoolName}}</strong> has been <strong>approved</strong> by the TutorSphere team.",
      "Buenas noticias: su escuela <strong>{{SchoolName}}</strong> ha sido <strong>aprobada</strong> por el equipo de TutorSphere.",
      "Gute Nachricht: Ihre Schule <strong>{{SchoolName}}</strong> wurde vom TutorSphere-Team <strong>genehmigt</strong>.",
      "Boas notícias: a sua escola <strong>{{SchoolName}}</strong> foi <strong>aprovada</strong> pela equipa TutorSphere.",
      "好消息：您的学校 <strong>{{SchoolName}}</strong> 已获 TutorSphere 团队<strong>批准</strong>。",
      "خبر سار: تمت <strong>الموافقة</strong> على مدرستك <strong>{{SchoolName}}</strong> من فريق TutorSphere."
    ),
    body2: L(
      "Vous pouvez maintenant vous connecter et commencer à gérer vos cours et vos élèves.",
      "You can now sign in and start managing your lessons and students.",
      "Ya puede iniciar sesión y gestionar sus clases y alumnos.",
      "Sie können sich jetzt anmelden und Unterricht sowie Schüler verwalten.",
      "Já pode iniciar sessão e gerir as suas aulas e alunos.",
      "您现在可以登录并开始管理课程和学生。",
      "يمكنك الآن تسجيل الدخول وبدء إدارة دروسك وطلابك."
    ),
    btn: L("Accéder à mon espace école", "Go to my school space", "Ir a mi espacio escolar", "Zum Schulbereich", "Aceder ao espaço da escola", "进入我的学校空间", "الانتقال إلى مساحة المدرسة"),
    btnUrl: "{{LoginUrl}}",
    text: L("Bonjour {{FirstName}}, votre école {{SchoolName}} est approuvée. Connexion : {{LoginUrl}}", "Hi {{FirstName}}, your school {{SchoolName}} is approved. Sign in: {{LoginUrl}}", "Hola {{FirstName}}, su escuela {{SchoolName}} está aprobada. Acceso: {{LoginUrl}}", "Hallo {{FirstName}}, Ihre Schule {{SchoolName}} ist genehmigt. Anmeldung: {{LoginUrl}}", "Olá {{FirstName}}, a sua escola {{SchoolName}} foi aprovada. Acesso: {{LoginUrl}}", "{{FirstName}}，您好，您的学校 {{SchoolName}} 已获批准。登录：{{LoginUrl}}", "مرحبًا {{FirstName}}، تمت الموافقة على مدرستك {{SchoolName}}. الدخول: {{LoginUrl}}")
  },
  {
    code: "LESSON_SCHEDULED",
    name: L("TutorSphere — Cours planifié", "TutorSphere — Lesson scheduled", "TutorSphere — Clase programada", "TutorSphere — Unterricht geplant", "TutorSphere — Aula agendada", "TutorSphere — 课程已安排", "TutorSphere — تمت جدولة الحصة"),
    subject: L("Nouveau cours planifié — {{Subject}}", "New lesson scheduled — {{Subject}}", "Nueva clase programada — {{Subject}}", "Neuer Unterricht geplant — {{Subject}}", "Nova aula agendada — {{Subject}}", "新课程已安排 — {{Subject}}", "حصة جديدة مجدولة — {{Subject}}"),
    title: L("Cours planifié", "Lesson scheduled", "Clase programada", "Unterricht geplant", "Aula agendada", "课程已安排", "حصة مجدولة"),
    helloRecipient: true,
    body: L(
      "Un nouveau cours a été planifié pour vous.",
      "A new lesson has been scheduled for you.",
      "Se ha programado una nueva clase para usted.",
      "Für Sie wurde ein neuer Unterricht geplant.",
      "Foi agendada uma nova aula para si.",
      "已为您安排了一节新课程。",
      "تمت جدولة حصة جديدة لك."
    ),
    labels: {
      subject: L("Matière", "Subject", "Materia", "Fach", "Disciplina", "科目", "المادة"),
      tutor: L("Tuteur", "Tutor", "Tutor", "Tutor", "Tutor", "导师", "المعلم"),
      date: L("Date", "Date", "Fecha", "Datum", "Data", "日期", "التاريخ")
    },
    tableBg: "#f5f3ff",
    btn: L("Voir mon calendrier", "View my calendar", "Ver mi calendario", "Kalender ansehen", "Ver o meu calendário", "查看我的日历", "عرض تقويمي"),
    btnUrl: "https://tutorsphere.gisebs.com/login",
    text: L("Cours planifié — {{Subject}} avec {{TutorName}} le {{LessonDate}}.", "Lesson scheduled — {{Subject}} with {{TutorName}} on {{LessonDate}}.", "Clase programada — {{Subject}} con {{TutorName}} el {{LessonDate}}.", "Unterricht geplant — {{Subject}} mit {{TutorName}} am {{LessonDate}}.", "Aula agendada — {{Subject}} com {{TutorName}} em {{LessonDate}}.", "课程已安排 — {{Subject}}，导师 {{TutorName}}，时间 {{LessonDate}}。", "حصة مجدولة — {{Subject}} مع {{TutorName}} في {{LessonDate}}.")
  },
  {
    code: "LESSON_REMINDER",
    name: L("TutorSphere — Rappel de cours", "TutorSphere — Lesson reminder", "TutorSphere — Recordatorio de clase", "TutorSphere — Unterrichtserinnerung", "TutorSphere — Lembrete de aula", "TutorSphere — 课程提醒", "TutorSphere — تذكير بالحصة"),
    subject: L("Rappel : votre cours de {{Subject}} est demain", "Reminder: your {{Subject}} lesson is tomorrow", "Recordatorio: su clase de {{Subject}} es mañana", "Erinnerung: Ihr {{Subject}}-Unterricht ist morgen", "Lembrete: a sua aula de {{Subject}} é amanhã", "提醒：您的 {{Subject}} 课程在明天", "تذكير: حصتك في {{Subject}} غدًا"),
    title: L("Rappel de cours", "Lesson reminder", "Recordatorio de clase", "Unterrichtserinnerung", "Lembrete de aula", "课程提醒", "تذكير بالحصة"),
    helloRecipient: true,
    body: L(
      "N'oubliez pas votre cours de demain !",
      "Don't forget your lesson tomorrow!",
      "¡No olvide su clase de mañana!",
      "Vergessen Sie Ihren Unterricht morgen nicht!",
      "Não se esqueça da sua aula de amanhã!",
      "别忘了明天的课程！",
      "لا تنسَ حصتك غدًا!"
    ),
    labels: {
      subject: L("Matière", "Subject", "Materia", "Fach", "Disciplina", "科目", "المادة"),
      tutor: L("Tuteur", "Tutor", "Tutor", "Tutor", "Tutor", "导师", "المعلم"),
      date: L("Date", "Date", "Fecha", "Datum", "Data", "日期", "التاريخ")
    },
    tableBg: "#f5f3ff",
    btn: L("Voir les détails", "View details", "Ver detalles", "Details ansehen", "Ver detalhes", "查看详情", "عرض التفاصيل"),
    btnUrl: "https://tutorsphere.gisebs.com/login",
    text: L("Rappel : cours de {{Subject}} avec {{TutorName}} le {{LessonDate}}.", "Reminder: {{Subject}} lesson with {{TutorName}} on {{LessonDate}}.", "Recordatorio: clase de {{Subject}} con {{TutorName}} el {{LessonDate}}.", "Erinnerung: {{Subject}}-Unterricht mit {{TutorName}} am {{LessonDate}}.", "Lembrete: aula de {{Subject}} com {{TutorName}} em {{LessonDate}}.", "提醒：{{Subject}} 课程，导师 {{TutorName}}，时间 {{LessonDate}}。", "تذكير: حصة {{Subject}} مع {{TutorName}} في {{LessonDate}}.")
  },
  {
    code: "LESSON_CANCELLED",
    name: L("TutorSphere — Cours annulé", "TutorSphere — Lesson cancelled", "TutorSphere — Clase cancelada", "TutorSphere — Unterricht abgesagt", "TutorSphere — Aula cancelada", "TutorSphere — 课程已取消", "TutorSphere — تم إلغاء الحصة"),
    subject: L("Cours annulé — {{Subject}}", "Lesson cancelled — {{Subject}}", "Clase cancelada — {{Subject}}", "Unterricht abgesagt — {{Subject}}", "Aula cancelada — {{Subject}}", "课程已取消 — {{Subject}}", "تم إلغاء الحصة — {{Subject}}"),
    title: L("Cours annulé", "Lesson cancelled", "Clase cancelada", "Unterricht abgesagt", "Aula cancelada", "课程已取消", "تم إلغاء الحصة"),
    titleColor: "#dc2626",
    helloRecipient: true,
    body: L(
      "Nous vous informons que le cours suivant a été <strong>annulé</strong> :",
      "We are writing to let you know the following lesson was <strong>cancelled</strong>:",
      "Le informamos que la siguiente clase ha sido <strong>cancelada</strong>:",
      "Wir informieren Sie, dass der folgende Unterricht <strong>abgesagt</strong> wurde:",
      "Informamos que a seguinte aula foi <strong>cancelada</strong>:",
      "以下课程已被<strong>取消</strong>：",
      "نعلمك أن الحصة التالية قد تم <strong>إلغاؤها</strong>:"
    ),
    labels: {
      subject: L("Matière", "Subject", "Materia", "Fach", "Disciplina", "科目", "المادة"),
      tutor: L("Tuteur", "Tutor", "Tutor", "Tutor", "Tutor", "导师", "المعلم"),
      date: L("Date prévue", "Scheduled date", "Fecha prevista", "Geplantes Datum", "Data prevista", "原定日期", "التاريخ المقرر")
    },
    tableBg: "#fff5f5",
    btn: L("Consulter mon calendrier", "View my calendar", "Consultar mi calendario", "Kalender öffnen", "Consultar o meu calendário", "查看我的日历", "عرض تقويمي"),
    btnUrl: "https://tutorsphere.gisebs.com/login",
    text: L("Cours annulé — {{Subject}} avec {{TutorName}} prévu le {{LessonDate}}.", "Lesson cancelled — {{Subject}} with {{TutorName}} scheduled for {{LessonDate}}.", "Clase cancelada — {{Subject}} con {{TutorName}} prevista el {{LessonDate}}.", "Unterricht abgesagt — {{Subject}} mit {{TutorName}} geplant am {{LessonDate}}.", "Aula cancelada — {{Subject}} com {{TutorName}} prevista para {{LessonDate}}.", "课程已取消 — {{Subject}}，导师 {{TutorName}}，原定 {{LessonDate}}。", "تم إلغاء الحصة — {{Subject}} مع {{TutorName}} المقررة في {{LessonDate}}.")
  },
  {
    code: "PARENT_PAYMENT_RECEIPT",
    name: L("TutorSphere — Reçu de paiement parent", "TutorSphere — Parent payment receipt", "TutorSphere — Recibo de pago del padre", "TutorSphere — Eltern-Zahlungsbeleg", "TutorSphere — Recibo de pagamento do responsável", "TutorSphere — 家长付款收据", "TutorSphere — إيصال دفع ولي الأمر"),
    subject: L("Reçu de paiement pour {{StudentName}} — TutorSphere", "Payment receipt for {{StudentName}} — TutorSphere", "Recibo de pago de {{StudentName}} — TutorSphere", "Zahlungsbeleg für {{StudentName}} — TutorSphere", "Recibo de pagamento de {{StudentName}} — TutorSphere", "{{StudentName}} 的付款收据 — TutorSphere", "إيصال دفع لـ {{StudentName}} — TutorSphere"),
    title: L("Reçu de paiement", "Payment receipt", "Recibo de pago", "Zahlungsbeleg", "Recibo de pagamento", "付款收据", "إيصال الدفع"),
    helloParentName: true,
    body: L(
      "Nous avons bien reçu votre paiement pour les cours de <strong>{{StudentName}}</strong>.",
      "We have received your payment for <strong>{{StudentName}}</strong>'s lessons.",
      "Hemos recibido su pago por las clases de <strong>{{StudentName}}</strong>.",
      "Wir haben Ihre Zahlung für den Unterricht von <strong>{{StudentName}}</strong> erhalten.",
      "Recebemos o seu pagamento pelas aulas de <strong>{{StudentName}}</strong>.",
      "我们已收到您为 <strong>{{StudentName}}</strong> 课程支付的款项。",
      "استلمنا دفعتك لحصص <strong>{{StudentName}}</strong>."
    ),
    studentLabel: L("Élève", "Student", "Alumno/a", "Schüler/in", "Aluno/a", "学生", "الطالب"),
    amountLabel: L("Montant", "Amount", "Importe", "Betrag", "Montante", "金额", "المبلغ"),
    btn: L("Voir ma facture", "View my invoice", "Ver mi factura", "Rechnung ansehen", "Ver a minha fatura", "查看我的发票", "عرض فاتورتي"),
    btnUrl: "{{InvoiceUrl}}",
    text: L("Reçu de paiement pour {{StudentName}} — {{Amount}}. Facture : {{InvoiceUrl}}", "Payment receipt for {{StudentName}} — {{Amount}}. Invoice: {{InvoiceUrl}}", "Recibo de pago de {{StudentName}} — {{Amount}}. Factura: {{InvoiceUrl}}", "Zahlungsbeleg für {{StudentName}} — {{Amount}}. Rechnung: {{InvoiceUrl}}", "Recibo de pagamento de {{StudentName}} — {{Amount}}. Fatura: {{InvoiceUrl}}", "{{StudentName}} 的付款收据 — {{Amount}}。发票：{{InvoiceUrl}}", "إيصال دفع لـ {{StudentName}} — {{Amount}}. الفاتورة: {{InvoiceUrl}}")
  },
  {
    code: "PARENT_PAYMENT_FAILED",
    name: L("TutorSphere — Échec de paiement parent", "TutorSphere — Parent payment failed", "TutorSphere — Fallo de pago del padre", "TutorSphere — Eltern-Zahlung fehlgeschlagen", "TutorSphere — Falha no pagamento do responsável", "TutorSphere — 家长付款失败", "TutorSphere — فشل دفع ولي الأمر"),
    subject: L("Problème de paiement — TutorSphere", "Payment issue — TutorSphere", "Problema de pago — TutorSphere", "Zahlungsproblem — TutorSphere", "Problema de pagamento — TutorSphere", "付款问题 — TutorSphere", "مشكلة في الدفع — TutorSphere"),
    title: L("Problème de paiement", "Payment issue", "Problema de pago", "Zahlungsproblem", "Problema de pagamento", "付款问题", "مشكلة في الدفع"),
    titleColor: "#dc2626",
    helloParentName: true,
    body: L(
      "Nous n'avons pas pu traiter votre paiement pour les cours de votre enfant.",
      "We could not process your payment for your child's lessons.",
      "No pudimos procesar su pago por las clases de su hijo/a.",
      "Wir konnten Ihre Zahlung für den Unterricht Ihres Kindes nicht verarbeiten.",
      "Não foi possível processar o pagamento das aulas do seu filho/a.",
      "我们无法处理您为孩子课程支付的款项。",
      "تعذّر معالجة دفعتك لحصص طفلك."
    ),
    body2: L(
      "Veuillez mettre à jour vos informations de paiement pour maintenir l'accès aux cours.",
      "Please update your payment details to keep access to lessons.",
      "Actualice sus datos de pago para mantener el acceso a las clases.",
      "Bitte aktualisieren Sie Ihre Zahlungsdaten, um den Zugang zum Unterricht zu behalten.",
      "Atualize os seus dados de pagamento para manter o acesso às aulas.",
      "请更新付款信息以保持课程访问权限。",
      "يرجى تحديث بيانات الدفع للحفاظ على الوصول إلى الحصص."
    ),
    btn: L("Mettre à jour mes informations", "Update my details", "Actualizar mis datos", "Daten aktualisieren", "Atualizar os meus dados", "更新我的信息", "تحديث بياناتي"),
    btnUrl: "https://tutorsphere.gisebs.com/settings/billing",
    text: L("Bonjour {{ParentName}}, votre paiement TutorSphere a échoué. Mettez vos informations à jour.", "Hi {{ParentName}}, your TutorSphere payment failed. Please update your details.", "Hola {{ParentName}}, falló su pago de TutorSphere. Actualice sus datos.", "Hallo {{ParentName}}, Ihre TutorSphere-Zahlung ist fehlgeschlagen. Bitte aktualisieren Sie Ihre Daten.", "Olá {{ParentName}}, o pagamento TutorSphere falhou. Atualize os seus dados.", "{{ParentName}}，您好，您的 TutorSphere 付款失败。请更新信息。", "مرحبًا {{ParentName}}، فشل دفع TutorSphere. حدّث بياناتك.")
  },
  {
    code: "INVOICE_READY",
    name: L("TutorSphere — Facture disponible", "TutorSphere — Invoice ready", "TutorSphere — Factura disponible", "TutorSphere — Rechnung verfügbar", "TutorSphere — Fatura disponível", "TutorSphere — 发票已就绪", "TutorSphere — الفاتورة جاهزة"),
    subject: L("Votre facture TutorSphere est disponible", "Your TutorSphere invoice is ready", "Su factura de TutorSphere está disponible", "Ihre TutorSphere-Rechnung ist verfügbar", "A sua fatura TutorSphere está disponível", "您的 TutorSphere 发票已就绪", "فاتورة TutorSphere جاهزة"),
    title: L("Facture disponible", "Invoice ready", "Factura disponible", "Rechnung verfügbar", "Fatura disponível", "发票已就绪", "الفاتورة جاهزة"),
    helloParentName: true,
    body: L(
      "Votre nouvelle facture TutorSphere est disponible au téléchargement.",
      "Your new TutorSphere invoice is available to download.",
      "Su nueva factura de TutorSphere está disponible para descargar.",
      "Ihre neue TutorSphere-Rechnung steht zum Download bereit.",
      "A sua nova fatura TutorSphere está disponível para descarregar.",
      "您的新 TutorSphere 发票可供下载。",
      "فاتورتك الجديدة من TutorSphere جاهزة للتنزيل."
    ),
    btn: L("Télécharger ma facture", "Download my invoice", "Descargar mi factura", "Rechnung herunterladen", "Descarregar a minha fatura", "下载我的发票", "تنزيل فاتورتي"),
    btnUrl: "{{InvoiceUrl}}",
    text: L("Bonjour {{ParentName}}, votre facture TutorSphere est disponible : {{InvoiceUrl}}", "Hi {{ParentName}}, your TutorSphere invoice is ready: {{InvoiceUrl}}", "Hola {{ParentName}}, su factura de TutorSphere está disponible: {{InvoiceUrl}}", "Hallo {{ParentName}}, Ihre TutorSphere-Rechnung ist verfügbar: {{InvoiceUrl}}", "Olá {{ParentName}}, a sua fatura TutorSphere está disponível: {{InvoiceUrl}}", "{{ParentName}}，您好，您的 TutorSphere 发票已就绪：{{InvoiceUrl}}", "مرحبًا {{ParentName}}، فاتورة TutorSphere جاهزة: {{InvoiceUrl}}")
  },
  {
    code: "PARENT_PAYMENT_OVERDUE",
    name: L("TutorSphere — Paiement en retard", "TutorSphere — Overdue payment", "TutorSphere — Pago atrasado", "TutorSphere — Überfällige Zahlung", "TutorSphere — Pagamento em atraso", "TutorSphere — 逾期付款", "TutorSphere — دفعة متأخرة"),
    subject: L("Rappel : paiement en attente pour {{StudentName}} — TutorSphere", "Reminder: payment pending for {{StudentName}} — TutorSphere", "Recordatorio: pago pendiente de {{StudentName}} — TutorSphere", "Erinnerung: ausstehende Zahlung für {{StudentName}} — TutorSphere", "Lembrete: pagamento pendente de {{StudentName}} — TutorSphere", "提醒：{{StudentName}} 的付款待处理 — TutorSphere", "تذكير: دفعة معلّقة لـ {{StudentName}} — TutorSphere"),
    title: L("Paiement en retard", "Overdue payment", "Pago atrasado", "Überfällige Zahlung", "Pagamento em atraso", "逾期付款", "دفعة متأخرة"),
    titleColor: "#dc2626",
    helloParentName: true,
    body: L(
      "Le paiement pour le cours <strong>{{CourseTitle}}</strong> de <strong>{{StudentName}}</strong> est toujours en attente.",
      "Payment for <strong>{{StudentName}}</strong>'s course <strong>{{CourseTitle}}</strong> is still pending.",
      "El pago del curso <strong>{{CourseTitle}}</strong> de <strong>{{StudentName}}</strong> sigue pendiente.",
      "Die Zahlung für den Kurs <strong>{{CourseTitle}}</strong> von <strong>{{StudentName}}</strong> steht noch aus.",
      "O pagamento do curso <strong>{{CourseTitle}}</strong> de <strong>{{StudentName}}</strong> ainda está pendente.",
      "<strong>{{StudentName}}</strong> 的课程 <strong>{{CourseTitle}}</strong> 付款仍待处理。",
      "لا تزال دفعة دورة <strong>{{CourseTitle}}</strong> لـ <strong>{{StudentName}}</strong> معلّقة."
    ),
    body2: L(
      "Merci de régulariser dès que possible afin d'activer ou de maintenir l'accès aux séances.",
      "Please settle as soon as possible to activate or keep access to sessions.",
      "Regularice lo antes posible para activar o mantener el acceso a las sesiones.",
      "Bitte begleichen Sie so bald wie möglich, um den Zugang zu den Sitzungen zu aktivieren oder zu behalten.",
      "Regularize o mais cedo possível para ativar ou manter o acesso às sessões.",
      "请尽快完成付款以激活或保持课程访问权限。",
      "يرجى التسوية في أقرب وقت لتفعيل أو الحفاظ على الوصول إلى الحصص."
    ),
    btn: L("Payer maintenant", "Pay now", "Pagar ahora", "Jetzt bezahlen", "Pagar agora", "立即付款", "ادفع الآن"),
    btnUrl: "{{PayUrl}}",
    text: L("Rappel : paiement en retard pour {{StudentName}} — {{CourseTitle}}. Payer : {{PayUrl}}", "Reminder: overdue payment for {{StudentName}} — {{CourseTitle}}. Pay: {{PayUrl}}", "Recordatorio: pago atrasado de {{StudentName}} — {{CourseTitle}}. Pagar: {{PayUrl}}", "Erinnerung: überfällige Zahlung für {{StudentName}} — {{CourseTitle}}. Zahlen: {{PayUrl}}", "Lembrete: pagamento em atraso de {{StudentName}} — {{CourseTitle}}. Pagar: {{PayUrl}}", "提醒：{{StudentName}} — {{CourseTitle}} 逾期付款。付款：{{PayUrl}}", "تذكير: دفعة متأخرة لـ {{StudentName}} — {{CourseTitle}}. ادفع: {{PayUrl}}")
  },
  {
    code: "COURSE_ENROLLMENT_REQUEST",
    name: L("TutorSphere — Demande d'inscription à un cours", "TutorSphere — Course enrollment request", "TutorSphere — Solicitud de inscripción a un curso", "TutorSphere — Kursanmeldungsanfrage", "TutorSphere — Pedido de inscrição num curso", "TutorSphere — 课程报名请求", "TutorSphere — طلب تسجيل في دورة"),
    subject: L("Nouvelle demande d'inscription — {{CourseTitle}}", "New enrollment request — {{CourseTitle}}", "Nueva solicitud de inscripción — {{CourseTitle}}", "Neue Anmeldungsanfrage — {{CourseTitle}}", "Novo pedido de inscrição — {{CourseTitle}}", "新的报名请求 — {{CourseTitle}}", "طلب تسجيل جديد — {{CourseTitle}}"),
    title: L("Nouvelle demande d'inscription", "New enrollment request", "Nueva solicitud de inscripción", "Neue Anmeldungsanfrage", "Novo pedido de inscrição", "新的报名请求", "طلب تسجيل جديد"),
    helloTutor: true,
    body: L(
      "<strong>{{StudentName}}</strong> souhaite s'inscrire au cours <strong>{{CourseTitle}}</strong>.",
      "<strong>{{StudentName}}</strong> wants to enroll in <strong>{{CourseTitle}}</strong>.",
      "<strong>{{StudentName}}</strong> desea inscribirse en el curso <strong>{{CourseTitle}}</strong>.",
      "<strong>{{StudentName}}</strong> möchte sich für den Kurs <strong>{{CourseTitle}}</strong> anmelden.",
      "<strong>{{StudentName}}</strong> deseja inscrever-se no curso <strong>{{CourseTitle}}</strong>.",
      "<strong>{{StudentName}}</strong> 希望报名课程 <strong>{{CourseTitle}}</strong>。",
      "يرغب <strong>{{StudentName}}</strong> في التسجيل في دورة <strong>{{CourseTitle}}</strong>."
    ),
    body2: L(
      "Connectez-vous pour accepter ou refuser la demande.",
      "Sign in to accept or decline the request.",
      "Inicie sesión para aceptar o rechazar la solicitud.",
      "Melden Sie sich an, um die Anfrage anzunehmen oder abzulehnen.",
      "Inicie sessão para aceitar ou recusar o pedido.",
      "登录以接受或拒绝该请求。",
      "سجّل الدخول لقبول الطلب أو رفضه."
    ),
    btn: L("Gérer les inscriptions", "Manage enrollments", "Gestionar inscripciones", "Anmeldungen verwalten", "Gerir inscrições", "管理报名", "إدارة التسجيلات"),
    btnUrl: "https://tutorsphere.gisebs.com/login",
    text: L("Demande d'inscription de {{StudentName}} au cours {{CourseTitle}}.", "Enrollment request from {{StudentName}} for {{CourseTitle}}.", "Solicitud de inscripción de {{StudentName}} al curso {{CourseTitle}}.", "Anmeldungsanfrage von {{StudentName}} für {{CourseTitle}}.", "Pedido de inscrição de {{StudentName}} no curso {{CourseTitle}}.", "{{StudentName}} 报名课程 {{CourseTitle}} 的请求。", "طلب تسجيل من {{StudentName}} في دورة {{CourseTitle}}.")
  },
  {
    code: "COURSE_ENROLLMENT_ACCEPTED",
    name: L("TutorSphere — Inscription au cours acceptée", "TutorSphere — Course enrollment accepted", "TutorSphere — Inscripción al curso aceptada", "TutorSphere — Kursanmeldung angenommen", "TutorSphere — Inscrição no curso aceite", "TutorSphere — 课程报名已接受", "TutorSphere — تم قبول التسجيل في الدورة"),
    subject: L("Inscription acceptée — {{CourseTitle}}", "Enrollment accepted — {{CourseTitle}}", "Inscripción aceptada — {{CourseTitle}}", "Anmeldung angenommen — {{CourseTitle}}", "Inscrição aceite — {{CourseTitle}}", "报名已接受 — {{CourseTitle}}", "تم قبول التسجيل — {{CourseTitle}}"),
    title: L("Inscription acceptée", "Enrollment accepted", "Inscripción aceptada", "Anmeldung angenommen", "Inscrição aceite", "报名已接受", "تم قبول التسجيل"),
    titleColor: "#16a34a",
    helloParentName: true,
    body: L(
      "L'inscription de <strong>{{StudentName}}</strong> au cours <strong>{{CourseTitle}}</strong> a été acceptée.",
      "<strong>{{StudentName}}</strong>'s enrollment in <strong>{{CourseTitle}}</strong> has been accepted.",
      "La inscripción de <strong>{{StudentName}}</strong> en el curso <strong>{{CourseTitle}}</strong> ha sido aceptada.",
      "Die Anmeldung von <strong>{{StudentName}}</strong> für den Kurs <strong>{{CourseTitle}}</strong> wurde angenommen.",
      "A inscrição de <strong>{{StudentName}}</strong> no curso <strong>{{CourseTitle}}</strong> foi aceite.",
      "<strong>{{StudentName}}</strong> 报名课程 <strong>{{CourseTitle}}</strong> 已获接受。",
      "تم قبول تسجيل <strong>{{StudentName}}</strong> في دورة <strong>{{CourseTitle}}</strong>."
    ),
    statusNote: true,
    btn: L("Continuer", "Continue", "Continuar", "Weiter", "Continuar", "继续", "متابعة"),
    btnUrl: "{{ActionUrl}}",
    text: L("Inscription de {{StudentName}} à {{CourseTitle}} acceptée. {{StatusNote}} {{ActionUrl}}", "Enrollment of {{StudentName}} in {{CourseTitle}} accepted. {{StatusNote}} {{ActionUrl}}", "Inscripción de {{StudentName}} en {{CourseTitle}} aceptada. {{StatusNote}} {{ActionUrl}}", "Anmeldung von {{StudentName}} für {{CourseTitle}} angenommen. {{StatusNote}} {{ActionUrl}}", "Inscrição de {{StudentName}} em {{CourseTitle}} aceite. {{StatusNote}} {{ActionUrl}}", "{{StudentName}} 报名 {{CourseTitle}} 已接受。{{StatusNote}} {{ActionUrl}}", "تم قبول تسجيل {{StudentName}} في {{CourseTitle}}. {{StatusNote}} {{ActionUrl}}")
  },
  {
    code: "TUTOR_STUDENT_PAYMENT_RECEIVED",
    name: L("TutorSphere — Paiement reçu (cours élève)", "TutorSphere — Payment received (student course)", "TutorSphere — Pago recibido (curso del alumno)", "TutorSphere — Zahlung eingegangen (Schülerkurs)", "TutorSphere — Pagamento recebido (curso do aluno)", "TutorSphere — 已收到付款（学生课程）", "TutorSphere — تم استلام الدفع (دورة الطالب)"),
    subject: L("Paiement reçu — {{StudentName}} / {{CourseTitle}}", "Payment received — {{StudentName}} / {{CourseTitle}}", "Pago recibido — {{StudentName}} / {{CourseTitle}}", "Zahlung eingegangen — {{StudentName}} / {{CourseTitle}}", "Pagamento recebido — {{StudentName}} / {{CourseTitle}}", "已收到付款 — {{StudentName}} / {{CourseTitle}}", "تم استلام الدفع — {{StudentName}} / {{CourseTitle}}"),
    title: L("Paiement reçu", "Payment received", "Pago recibido", "Zahlung eingegangen", "Pagamento recebido", "已收到付款", "تم استلام الدفع"),
    titleColor: "#16a34a",
    helloTutor: true,
    body: L(
      "Un paiement a été reçu pour <strong>{{StudentName}}</strong> — cours <strong>{{CourseTitle}}</strong>.",
      "A payment was received for <strong>{{StudentName}}</strong> — course <strong>{{CourseTitle}}</strong>.",
      "Se recibió un pago por <strong>{{StudentName}}</strong> — curso <strong>{{CourseTitle}}</strong>.",
      "Eine Zahlung für <strong>{{StudentName}}</strong> — Kurs <strong>{{CourseTitle}}</strong> ist eingegangen.",
      "Foi recebido um pagamento por <strong>{{StudentName}}</strong> — curso <strong>{{CourseTitle}}</strong>.",
      "已收到 <strong>{{StudentName}}</strong> — 课程 <strong>{{CourseTitle}}</strong> 的付款。",
      "تم استلام دفعة لـ <strong>{{StudentName}}</strong> — دورة <strong>{{CourseTitle}}</strong>."
    ),
    amountLabel: L("Montant", "Amount", "Importe", "Betrag", "Montante", "金额", "المبلغ"),
    btn: L("Voir mon espace", "View my space", "Ver mi espacio", "Meinen Bereich öffnen", "Ver o meu espaço", "查看我的空间", "عرض مساحتي"),
    btnUrl: "https://tutorsphere.gisebs.com/login",
    text: L("Paiement reçu : {{Amount}} pour {{StudentName}} — {{CourseTitle}}.", "Payment received: {{Amount}} for {{StudentName}} — {{CourseTitle}}.", "Pago recibido: {{Amount}} por {{StudentName}} — {{CourseTitle}}.", "Zahlung eingegangen: {{Amount}} für {{StudentName}} — {{CourseTitle}}.", "Pagamento recebido: {{Amount}} por {{StudentName}} — {{CourseTitle}}.", "已收到付款：{{Amount}}，{{StudentName}} — {{CourseTitle}}。", "تم استلام الدفع: {{Amount}} لـ {{StudentName}} — {{CourseTitle}}.")
  },
  {
    code: "EXPERT_TEACHER_PENDING",
    name: L("TutorSphere — Enseignant en attente (expert)", "TutorSphere — Teacher pending (expert)", "TutorSphere — Profesor pendiente (experto)", "TutorSphere — Lehrer ausstehend (Experte)", "TutorSphere — Professor pendente (especialista)", "TutorSphere — 待审教师（专家）", "TutorSphere — معلم قيد الانتظار (خبير)"),
    subject: L("Nouvelle demande enseignant à valider — {{SchoolName}}", "New teacher application to review — {{SchoolName}}", "Nueva solicitud de profesor por revisar — {{SchoolName}}", "Neuer Lehrerantrag zur Prüfung — {{SchoolName}}", "Novo pedido de professor para rever — {{SchoolName}}", "待审教师申请 — {{SchoolName}}", "طلب معلم جديد للمراجعة — {{SchoolName}}"),
    title: L("Demande enseignant à valider", "Teacher application to review", "Solicitud de profesor por revisar", "Lehrerantrag zur Prüfung", "Pedido de professor para rever", "待审教师申请", "طلب معلم للمراجعة"),
    helloExpert: true,
    body: L(
      "Une école a soumis un compte enseignant en attente de validation.",
      "A school has submitted a teacher account pending validation.",
      "Una escuela ha enviado una cuenta de profesor pendiente de validación.",
      "Eine Schule hat ein Lehrerkonto zur Validierung eingereicht.",
      "Uma escola submeteu uma conta de professor pendente de validação.",
      "一所学校已提交待审教师帐户。",
      "قدّمت مدرسة حساب معلم بانتظار التحقق."
    ),
    expertLabels: {
      school: L("École", "School", "Escuela", "Schule", "Escola", "学校", "المدرسة"),
      country: L("Pays", "Country", "País", "Land", "País", "国家", "البلد")
    },
    body2: L(
      "Connectez-vous pour examiner le dossier et approuver ou refuser la demande.",
      "Sign in to review the file and approve or decline the application.",
      "Inicie sesión para revisar el expediente y aprobar o rechazar la solicitud.",
      "Melden Sie sich an, um die Unterlagen zu prüfen und den Antrag anzunehmen oder abzulehnen.",
      "Inicie sessão para rever o processo e aprovar ou recusar o pedido.",
      "请登录以审核材料并批准或拒绝该申请。",
      "سجّل الدخول لمراجعة الملف والموافقة على الطلب أو رفضه."
    ),
    btn: L("Examiner la demande", "Review application", "Revisar solicitud", "Antrag prüfen", "Rever pedido", "审核申请", "مراجعة الطلب"),
    btnUrl: "{{ReviewUrl}}",
    text: L(
      "Bonjour {{ExpertFirstName}}, demande enseignant à valider — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
      "Hello {{ExpertFirstName}}, teacher application to review — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
      "Hola {{ExpertFirstName}}, solicitud de profesor por revisar — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
      "Hallo {{ExpertFirstName}}, Lehrerantrag zur Prüfung — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
      "Olá {{ExpertFirstName}}, pedido de professor para rever — {{SchoolName}} ({{Country}}). {{ReviewUrl}}",
      "{{ExpertFirstName}}，您好，待审教师申请 — {{SchoolName}}（{{Country}}）。{{ReviewUrl}}",
      "مرحبًا {{ExpertFirstName}}، طلب معلم للمراجعة — {{SchoolName}} ({{Country}}). {{ReviewUrl}}"
    )
  },
  {
    code: "EXPERT_INVITE",
    name: L("TutorSphere — Invitation expert", "TutorSphere — Expert invitation", "TutorSphere — Invitación experto", "TutorSphere — Experten-Einladung", "TutorSphere — Convite especialista", "TutorSphere — 专家邀请", "TutorSphere — دعوة خبير"),
    subject: L("Bienvenue {{FirstName}} — accès expert {{GroupName}}", "Welcome {{FirstName}} — expert access {{GroupName}}", "Bienvenido/a {{FirstName}} — acceso experto {{GroupName}}", "Willkommen {{FirstName}} — Expertenzugang {{GroupName}}", "Bem-vindo(a) {{FirstName}} — acesso especialista {{GroupName}}", "欢迎 {{FirstName}} — 专家访问 {{GroupName}}", "مرحبًا {{FirstName}} — وصول خبير {{GroupName}}"),
    title: L("Votre accès à l'espace expert", "Your expert space access", "Su acceso al espacio experto", "Ihr Zugang zum Expertenbereich", "O seu acesso ao espaço de especialista", "您的专家空间访问权限", "وصولك إلى مساحة الخبير"),
    hello: true,
    body: L(
      "Vous avez été invité(e) à rejoindre le groupe d'experts <strong>{{GroupName}}</strong> sur TutorSphere. Voici vos identifiants de connexion :",
      "You have been invited to join the expert group <strong>{{GroupName}}</strong> on TutorSphere. Here are your sign-in credentials:",
      "Ha sido invitado/a a unirse al grupo de expertos <strong>{{GroupName}}</strong> en TutorSphere. Estas son sus credenciales de acceso:",
      "Sie wurden eingeladen, der Expertengruppe <strong>{{GroupName}}</strong> auf TutorSphere beizutreten. Hier sind Ihre Anmeldedaten:",
      "Foi convidado(a) a juntar-se ao grupo de especialistas <strong>{{GroupName}}</strong> no TutorSphere. Eis as suas credenciais de acesso:",
      "您已受邀加入 TutorSphere 专家组 <strong>{{GroupName}}</strong>。以下是您的登录凭据：",
      "تمت دعوتك للانضمام إلى مجموعة الخبراء <strong>{{GroupName}}</strong> على TutorSphere. إليك بيانات تسجيل الدخول:"
    ),
    inviteLabels: {
      email: L("E-mail de connexion", "Sign-in email", "Correo de acceso", "Anmelde-E-Mail", "E-mail de acesso", "登录电子邮件", "بريد الدخول"),
      password: L("Mot de passe temporaire", "Temporary password", "Contraseña temporal", "Temporäres Passwort", "Palavra-passe temporária", "临时密码", "كلمة المرور المؤقتة"),
      group: L("Groupe d'experts", "Expert group", "Grupo de expertos", "Expertengruppe", "Grupo de especialistas", "专家组", "مجموعة الخبراء"),
      loginUrl: L("Page de connexion expert", "Expert sign-in page", "Página de acceso experto", "Experten-Anmeldeseite", "Página de acesso especialista", "专家登录页", "صفحة دخول الخبير")
    },
    note: L(
      "Pour votre sécurité, <strong>changez ce mot de passe</strong> dès la première connexion à l'espace expert.",
      "For your security, <strong>change this password</strong> as soon as you first sign in to the expert space.",
      "Por su seguridad, <strong>cambie esta contraseña</strong> en el primer acceso al espacio experto.",
      "Aus Sicherheitsgründen <strong>ändern Sie dieses Passwort</strong> bei der ersten Anmeldung im Expertenbereich.",
      "Por segurança, <strong>altere esta palavra-passe</strong> no primeiro acesso ao espaço de especialista.",
      "为安全起见，请在首次登录专家空间时<strong>更改此密码</strong>。",
      "لأمانك، <strong>غيّر كلمة المرور هذه</strong> عند أول دخول إلى مساحة الخبير."
    ),
    body2: L(
      "Étapes : 1) Ouvrez la page de connexion expert ci-dessous 2) Saisissez l'e-mail et le mot de passe temporaire 3) Choisissez un nouveau mot de passe.",
      "Steps: 1) Open the expert sign-in page below 2) Enter the email and temporary password 3) Choose a new password.",
      "Pasos: 1) Abra la página de acceso experto abajo 2) Introduzca el correo y la contraseña temporal 3) Elija una nueva contraseña.",
      "Schritte: 1) Öffnen Sie die Experten-Anmeldeseite unten 2) Geben Sie E-Mail und temporäres Passwort ein 3) Wählen Sie ein neues Passwort.",
      "Passos: 1) Abra a página de acesso especialista abaixo 2) Introduza o e-mail e a palavra-passe temporária 3) Escolha uma nova palavra-passe.",
      "步骤：1）打开下方专家登录页 2）输入电子邮件和临时密码 3）设置新密码。",
      "الخطوات: 1) افتح صفحة دخول الخبير أدناه 2) أدخل البريد وكلمة المرور المؤقتة 3) اختر كلمة مرور جديدة."
    ),
    btn: L("Se connecter à l'espace expert", "Sign in to expert space", "Iniciar sesión en el espacio experto", "Zum Expertenbereich anmelden", "Iniciar sessão no espaço de especialista", "登录专家空间", "تسجيل الدخول إلى مساحة الخبير"),
    btnUrl: "{{LoginUrl}}",
    footer: expertInviteFooter,
    text: L(
      "Bonjour {{FirstName}}, invitation expert {{GroupName}}. E-mail : {{Email}}. Mot de passe temporaire : {{TemporaryPassword}}. Changez ce mot de passe à la première connexion. Connexion expert : {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS : https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
      "Hello {{FirstName}}, expert invite {{GroupName}}. Email: {{Email}}. Temporary password: {{TemporaryPassword}}. Change this password on first login. Expert login: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
      "Hola {{FirstName}}, invitación experto {{GroupName}}. Correo: {{Email}}. Contraseña temporal: {{TemporaryPassword}}. Cambie esta contraseña en el primer acceso. Acceso experto: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
      "Hallo {{FirstName}}, Experten-Einladung {{GroupName}}. E-Mail: {{Email}}. Temporäres Passwort: {{TemporaryPassword}}. Ändern Sie dieses Passwort bei der ersten Anmeldung. Experten-Login: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
      "Olá {{FirstName}}, convite especialista {{GroupName}}. E-mail: {{Email}}. Palavra-passe temporária: {{TemporaryPassword}}. Altere esta palavra-passe no primeiro acesso. Acesso especialista: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com | TutorSphere | Agentia | CogniDoc | GISEBoutique | ComptaDoc",
      "{{FirstName}}，您好，专家邀请 {{GroupName}}。电子邮件：{{Email}}。临时密码：{{TemporaryPassword}}。请在首次登录时更改密码。专家登录：{{LoginUrl}}（https://tutorsphere.gisebs.com/login/expert）。GISEBS：https://gisebs.com",
      "مرحبًا {{FirstName}}، دعوة خبير {{GroupName}}. البريد: {{Email}}. كلمة المرور المؤقتة: {{TemporaryPassword}}. غيّر كلمة المرور عند أول دخول. دخول الخبير: {{LoginUrl}} (https://tutorsphere.gisebs.com/login/expert). GISEBS: https://gisebs.com"
    )
  },
  {
    code: "EXPERT_ADDED_TO_GROUP",
    name: L("TutorSphere — Ajouté au groupe expert", "TutorSphere — Added to expert group", "TutorSphere — Añadido al grupo experto", "TutorSphere — Zur Expertengruppe hinzugefügt", "TutorSphere — Adicionado ao grupo de especialistas", "TutorSphere — 已加入专家组", "TutorSphere — أُضيفت إلى مجموعة الخبراء"),
    subject: L("{{FirstName}}, vous avez été ajouté(e) à {{GroupName}}", "{{FirstName}}, you were added to {{GroupName}}", "{{FirstName}}, ha sido añadido/a a {{GroupName}}", "{{FirstName}}, Sie wurden zu {{GroupName}} hinzugefügt", "{{FirstName}}, foi adicionado(a) a {{GroupName}}", "{{FirstName}}，您已加入 {{GroupName}}", "{{FirstName}}، تمت إضافتك إلى {{GroupName}}"),
    title: L("Ajouté à un groupe d'experts", "Added to an expert group", "Añadido a un grupo de expertos", "Zu einer Expertengruppe hinzugefügt", "Adicionado a um grupo de especialistas", "已加入专家组", "أُضيفت إلى مجموعة خبراء"),
    hello: true,
    body: L(
      "Vous avez été ajouté(e) au groupe d'experts <strong>{{GroupName}}</strong> sur TutorSphere. Utilisez vos identifiants existants pour vous connecter.",
      "You have been added to the expert group <strong>{{GroupName}}</strong> on TutorSphere. Use your existing credentials to sign in.",
      "Ha sido añadido/a al grupo de expertos <strong>{{GroupName}}</strong> en TutorSphere. Use sus credenciales existentes para iniciar sesión.",
      "Sie wurden der Expertengruppe <strong>{{GroupName}}</strong> auf TutorSphere hinzugefügt. Melden Sie sich mit Ihren bestehenden Zugangsdaten an.",
      "Foi adicionado(a) ao grupo de especialistas <strong>{{GroupName}}</strong> no TutorSphere. Utilize as suas credenciais existentes para iniciar sessão.",
      "您已加入 TutorSphere 专家组 <strong>{{GroupName}}</strong>。请使用现有凭据登录。",
      "تمت إضافتك إلى مجموعة الخبراء <strong>{{GroupName}}</strong> على TutorSphere. استخدم بيانات اعتمادك الحالية لتسجيل الدخول."
    ),
    addedLabels: {
      email: L("Compte", "Account", "Cuenta", "Konto", "Conta", "帐户", "الحساب"),
      group: L("Groupe d'experts", "Expert group", "Grupo de expertos", "Expertengruppe", "Grupo de especialistas", "专家组", "مجموعة الخبراء")
    },
    btn: L("Se connecter à l'espace expert", "Sign in to expert space", "Iniciar sesión en el espacio experto", "Zum Expertenbereich anmelden", "Iniciar sessão no espaço de especialista", "登录专家空间", "تسجيل الدخول إلى مساحة الخبير"),
    btnUrl: "{{LoginUrl}}",
    text: L(
      "Bonjour {{FirstName}}, vous avez été ajouté(e) au groupe {{GroupName}} (compte {{Email}}). Connexion : {{LoginUrl}}",
      "Hello {{FirstName}}, you were added to group {{GroupName}} (account {{Email}}). Login: {{LoginUrl}}",
      "Hola {{FirstName}}, ha sido añadido/a al grupo {{GroupName}} (cuenta {{Email}}). Acceso: {{LoginUrl}}",
      "Hallo {{FirstName}}, Sie wurden der Gruppe {{GroupName}} hinzugefügt (Konto {{Email}}). Anmeldung: {{LoginUrl}}",
      "Olá {{FirstName}}, foi adicionado(a) ao grupo {{GroupName}} (conta {{Email}}). Acesso: {{LoginUrl}}",
      "{{FirstName}}，您好，您已加入小组 {{GroupName}}（帐户 {{Email}}）。登录：{{LoginUrl}}",
      "مرحبًا {{FirstName}}، تمت إضافتك إلى المجموعة {{GroupName}} (الحساب {{Email}}). الدخول: {{LoginUrl}}"
    )
  },
  {
    code: "EXPERT_TEACHER_APPROVED",
    name: L("TutorSphere — Enseignant approuvé (expert)", "TutorSphere — Teacher approved (expert)", "TutorSphere — Profesor aprobado (experto)", "TutorSphere — Lehrer genehmigt (Experte)", "TutorSphere — Professor aprovado (especialista)", "TutorSphere — 教师已批准（专家）", "TutorSphere — تمت الموافقة على المعلم (خبير)"),
    subject: L("Bonne nouvelle : votre profil enseignant est approuvé", "Good news: your teacher profile is approved", "Buenas noticias: su perfil de profesor está aprobado", "Gute Nachricht: Ihr Lehrerprofil wurde genehmigt", "Boa notícia: o seu perfil de professor foi aprovado", "好消息：您的教师资料已获批准", "خبر سار: تمت الموافقة على ملفك كمعلم"),
    title: L("Profil enseignant approuvé", "Teacher profile approved", "Perfil de profesor aprobado", "Lehrerprofil genehmigt", "Perfil de professor aprovado", "教师资料已批准", "تمت الموافقة على ملف المعلم"),
    titleColor: "#16a34a",
    hello: true,
    body: L(
      "Votre demande pour <strong>{{SchoolName}}</strong> a été <strong>approuvée</strong> par le groupe d'experts <strong>{{GroupName}}</strong>.",
      "Your application for <strong>{{SchoolName}}</strong> has been <strong>approved</strong> by the expert group <strong>{{GroupName}}</strong>.",
      "Su solicitud para <strong>{{SchoolName}}</strong> ha sido <strong>aprobada</strong> por el grupo de expertos <strong>{{GroupName}}</strong>.",
      "Ihr Antrag für <strong>{{SchoolName}}</strong> wurde von der Expertengruppe <strong>{{GroupName}}</strong> <strong>genehmigt</strong>.",
      "O seu pedido para <strong>{{SchoolName}}</strong> foi <strong>aprovado</strong> pelo grupo de especialistas <strong>{{GroupName}}</strong>.",
      "您针对 <strong>{{SchoolName}}</strong> 的申请已由专家组 <strong>{{GroupName}}</strong> <strong>批准</strong>。",
      "تمت <strong>الموافقة</strong> على طلبك لـ <strong>{{SchoolName}}</strong> من مجموعة الخبراء <strong>{{GroupName}}</strong>."
    ),
    decisionLabels: {
      school: L("École / profil", "School / profile", "Escuela / perfil", "Schule / Profil", "Escola / perfil", "学校 / 资料", "المدرسة / الملف"),
      group: L("Groupe d'experts", "Expert group", "Grupo de expertos", "Expertengruppe", "Grupo de especialistas", "专家组", "مجموعة الخبراء"),
      notes: L("Commentaire", "Comment", "Comentario", "Kommentar", "Comentário", "备注", "تعليق")
    },
    body2: L(
      "Vous pouvez vous connecter à votre espace enseignant pour poursuivre votre activité sur TutorSphere.",
      "You can sign in to your teacher space to continue on TutorSphere.",
      "Puede iniciar sesión en su espacio de profesor para continuar en TutorSphere.",
      "Melden Sie sich in Ihrem Lehrerbereich an, um auf TutorSphere fortzufahren.",
      "Pode iniciar sessão no seu espaço de professor para continuar no TutorSphere.",
      "您可以登录教师空间继续使用 TutorSphere。",
      "يمكنك تسجيل الدخول إلى مساحة المعلم لمتابعة نشاطك على TutorSphere."
    ),
    btn: L("Accéder à mon espace enseignant", "Go to my teacher space", "Ir a mi espacio de profesor", "Zum Lehrerbereich", "Ir para o meu espaço de professor", "进入我的教师空间", "الانتقال إلى مساحة المعلم"),
    btnUrl: "{{LoginUrl}}",
    text: L(
      "Bonjour {{FirstName}}, votre profil {{SchoolName}} a été approuvé par {{GroupName}}. Commentaire : {{Notes}}. Connexion : {{LoginUrl}}",
      "Hello {{FirstName}}, your profile {{SchoolName}} was approved by {{GroupName}}. Comment: {{Notes}}. Login: {{LoginUrl}}",
      "Hola {{FirstName}}, su perfil {{SchoolName}} fue aprobado por {{GroupName}}. Comentario: {{Notes}}. Acceso: {{LoginUrl}}",
      "Hallo {{FirstName}}, Ihr Profil {{SchoolName}} wurde von {{GroupName}} genehmigt. Kommentar: {{Notes}}. Anmeldung: {{LoginUrl}}",
      "Olá {{FirstName}}, o seu perfil {{SchoolName}} foi aprovado por {{GroupName}}. Comentário: {{Notes}}. Acesso: {{LoginUrl}}",
      "{{FirstName}}，您好，您的资料 {{SchoolName}} 已由 {{GroupName}} 批准。备注：{{Notes}}。登录：{{LoginUrl}}",
      "مرحبًا {{FirstName}}، تمت الموافقة على ملفك {{SchoolName}} من {{GroupName}}. التعليق: {{Notes}}. الدخول: {{LoginUrl}}"
    )
  },
  {
    code: "EXPERT_TEACHER_REJECTED",
    name: L("TutorSphere — Enseignant refusé (expert)", "TutorSphere — Teacher rejected (expert)", "TutorSphere — Profesor rechazado (experto)", "TutorSphere — Lehrer abgelehnt (Experte)", "TutorSphere — Professor recusado (especialista)", "TutorSphere — 教师已拒绝（专家）", "TutorSphere — رُفض المعلم (خبير)"),
    subject: L("Décision sur votre demande enseignant — {{SchoolName}}", "Decision on your teacher application — {{SchoolName}}", "Decisión sobre su solicitud de profesor — {{SchoolName}}", "Entscheidung zu Ihrem Lehrerantrag — {{SchoolName}}", "Decisão sobre o seu pedido de professor — {{SchoolName}}", "关于您教师申请的决定 — {{SchoolName}}", "قرار بشأن طلبك كمعلم — {{SchoolName}}"),
    title: L("Demande enseignant non approuvée", "Teacher application not approved", "Solicitud de profesor no aprobada", "Lehrerantrag nicht genehmigt", "Pedido de professor não aprovado", "教师申请未获批准", "لم تتم الموافقة على طلب المعلم"),
    titleColor: "#dc2626",
    hello: true,
    body: L(
      "Après examen, votre demande pour <strong>{{SchoolName}}</strong> n'a pas été approuvée par le groupe d'experts <strong>{{GroupName}}</strong>.",
      "After review, your application for <strong>{{SchoolName}}</strong> was not approved by the expert group <strong>{{GroupName}}</strong>.",
      "Tras la revisión, su solicitud para <strong>{{SchoolName}}</strong> no fue aprobada por el grupo de expertos <strong>{{GroupName}}</strong>.",
      "Nach Prüfung wurde Ihr Antrag für <strong>{{SchoolName}}</strong> von der Expertengruppe <strong>{{GroupName}}</strong> nicht genehmigt.",
      "Após análise, o seu pedido para <strong>{{SchoolName}}</strong> não foi aprovado pelo grupo de especialistas <strong>{{GroupName}}</strong>.",
      "经审核，专家组 <strong>{{GroupName}}</strong> 未批准您针对 <strong>{{SchoolName}}</strong> 的申请。",
      "بعد المراجعة، لم تتم الموافقة على طلبك لـ <strong>{{SchoolName}}</strong> من مجموعة الخبراء <strong>{{GroupName}}</strong>."
    ),
    decisionLabels: {
      school: L("École / profil", "School / profile", "Escuela / perfil", "Schule / Profil", "Escola / perfil", "学校 / 资料", "المدرسة / الملف"),
      group: L("Groupe d'experts", "Expert group", "Grupo de expertos", "Expertengruppe", "Grupo de especialistas", "专家组", "مجموعة الخبراء"),
      notes: L("Motif / commentaire", "Reason / comment", "Motivo / comentario", "Grund / Kommentar", "Motivo / comentário", "原因 / 备注", "السبب / التعليق")
    },
    body2: L(
      "Vous pouvez mettre à jour votre dossier (documents, diplômes, présentation) puis soumettre à nouveau une demande si besoin.",
      "You can update your file (documents, diplomas, presentation) and submit a new application if needed.",
      "Puede actualizar su expediente (documentos, diplomas, presentación) y volver a enviar una solicitud si lo necesita.",
      "Sie können Ihre Unterlagen (Dokumente, Abschlüsse, Präsentation) aktualisieren und bei Bedarf erneut beantragen.",
      "Pode atualizar o seu processo (documentos, diplomas, apresentação) e voltar a submeter um pedido se necessário.",
      "您可以更新材料（文件、学历、介绍），如有需要可重新提交申请。",
      "يمكنك تحديث ملفك (المستندات، الشهادات، العرض) ثم إعادة تقديم الطلب عند الحاجة."
    ),
    btn: L("Ouvrir mon espace enseignant", "Open my teacher space", "Abrir mi espacio de profesor", "Lehrerbereich öffnen", "Abrir o meu espaço de professor", "打开我的教师空间", "فتح مساحة المعلم"),
    btnUrl: "{{LoginUrl}}",
    text: L(
      "Bonjour {{FirstName}}, votre demande {{SchoolName}} n'a pas été approuvée par {{GroupName}}. Motif : {{Notes}}. Connexion : {{LoginUrl}}",
      "Hello {{FirstName}}, your application {{SchoolName}} was not approved by {{GroupName}}. Reason: {{Notes}}. Login: {{LoginUrl}}",
      "Hola {{FirstName}}, su solicitud {{SchoolName}} no fue aprobada por {{GroupName}}. Motivo: {{Notes}}. Acceso: {{LoginUrl}}",
      "Hallo {{FirstName}}, Ihr Antrag {{SchoolName}} wurde von {{GroupName}} nicht genehmigt. Grund: {{Notes}}. Anmeldung: {{LoginUrl}}",
      "Olá {{FirstName}}, o seu pedido {{SchoolName}} não foi aprovado por {{GroupName}}. Motivo: {{Notes}}. Acesso: {{LoginUrl}}",
      "{{FirstName}}，您好，您的申请 {{SchoolName}} 未获 {{GroupName}} 批准。原因：{{Notes}}。登录：{{LoginUrl}}",
      "مرحبًا {{FirstName}}، لم تتم الموافقة على طلبك {{SchoolName}} من {{GroupName}}. السبب: {{Notes}}. الدخول: {{LoginUrl}}"
    )
  },
  {
    code: "EXPERT_TEACHER_APPLY_INVITE",
    name: L("TutorSphere — Invitation candidature enseignant", "TutorSphere — Teacher application invite", "TutorSphere — Invitación candidatura profesor", "TutorSphere — Einladung Lehrerbewerbung", "TutorSphere — Convite candidatura professor", "TutorSphere — 教师申请邀请", "TutorSphere — دعوة تقديم طلب معلم"),
    subject: L("{{ExpertName}} vous invite à déposer votre candidature enseignant", "{{ExpertName}} invites you to submit your teacher application", "{{ExpertName}} le invita a presentar su candidatura de profesor", "{{ExpertName}} lädt Sie ein, Ihre Lehrerbewerbung einzureichen", "{{ExpertName}} convida-o a submeter a sua candidatura de professor", "{{ExpertName}} 邀请您提交教师申请", "{{ExpertName}} يدعوك لتقديم طلبك كمعلم"),
    title: L("Invitation à candidater", "Invitation to apply", "Invitación a postular", "Einladung zur Bewerbung", "Convite para candidatar-se", "申请邀请", "دعوة للتقديم"),
    hello: true,
    body: L(
      "<strong>{{ExpertName}}</strong> (groupe d'experts <strong>{{GroupName}}</strong>) vous invite à déposer votre candidature enseignant sur TutorSphere pour examen.",
      "<strong>{{ExpertName}}</strong> (expert group <strong>{{GroupName}}</strong>) invites you to submit your teacher application on TutorSphere for review.",
      "<strong>{{ExpertName}}</strong> (grupo de expertos <strong>{{GroupName}}</strong>) le invita a presentar su candidatura de profesor en TutorSphere para revisión.",
      "<strong>{{ExpertName}}</strong> (Expertengruppe <strong>{{GroupName}}</strong>) lädt Sie ein, Ihre Lehrerbewerbung auf TutorSphere zur Prüfung einzureichen.",
      "<strong>{{ExpertName}}</strong> (grupo de especialistas <strong>{{GroupName}}</strong>) convida-o a submeter a sua candidatura de professor no TutorSphere para análise.",
      "<strong>{{ExpertName}}</strong>（专家组 <strong>{{GroupName}}</strong>）邀请您在 TutorSphere 提交教师申请以供审核。",
      "<strong>{{ExpertName}}</strong> (مجموعة الخبراء <strong>{{GroupName}}</strong>) يدعوك لتقديم طلبك كمعلم على TutorSphere للمراجعة."
    ),
    note: L("{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}"),
    body2: L(
      "Créez votre compte et soumettez votre dossier via le lien ci-dessous. URL : {{ApplyUrl}}",
      "Create your account and submit your file using the link below. URL: {{ApplyUrl}}",
      "Cree su cuenta y envíe su expediente con el enlace de abajo. URL: {{ApplyUrl}}",
      "Erstellen Sie Ihr Konto und reichen Sie Ihre Unterlagen über den Link unten ein. URL: {{ApplyUrl}}",
      "Crie a sua conta e submeta o seu processo através do link abaixo. URL: {{ApplyUrl}}",
      "请通过下方链接创建账户并提交材料。URL：{{ApplyUrl}}",
      "أنشئ حسابك وقدّم ملفك عبر الرابط أدناه. الرابط: {{ApplyUrl}}"
    ),
    btn: L("Déposer ma candidature", "Submit my application", "Presentar mi candidatura", "Bewerbung einreichen", "Submeter a minha candidatura", "提交我的申请", "تقديم طلبي"),
    btnUrl: "{{ApplyUrl}}",
    text: L(
      "Bonjour {{FirstName}}, {{ExpertName}} ({{GroupName}}) vous invite à candidater. {{PersonalMessage}} Lien : {{ApplyUrl}}",
      "Hello {{FirstName}}, {{ExpertName}} ({{GroupName}}) invites you to apply. {{PersonalMessage}} Link: {{ApplyUrl}}",
      "Hola {{FirstName}}, {{ExpertName}} ({{GroupName}}) le invita a postular. {{PersonalMessage}} Enlace: {{ApplyUrl}}",
      "Hallo {{FirstName}}, {{ExpertName}} ({{GroupName}}) lädt Sie zur Bewerbung ein. {{PersonalMessage}} Link: {{ApplyUrl}}",
      "Olá {{FirstName}}, {{ExpertName}} ({{GroupName}}) convida-o a candidatar-se. {{PersonalMessage}} Link: {{ApplyUrl}}",
      "{{FirstName}}，您好，{{ExpertName}}（{{GroupName}}）邀请您申请。{{PersonalMessage}} 链接：{{ApplyUrl}}",
      "مرحبًا {{FirstName}}، {{ExpertName}} ({{GroupName}}) يدعوك للتقديم. {{PersonalMessage}} الرابط: {{ApplyUrl}}"
    )
  },
  {
    code: "EXPERT_MEMBERSHIP_INVITE",
    name: L(
      "TutorSphere — Invitation membre Expert",
      "TutorSphere — Expert membership invite",
      "TutorSphere — Invitación miembro experto",
      "TutorSphere — Einladung Expertenmitglied",
      "TutorSphere — Convite membro especialista",
      "TutorSphere — 专家成员邀请",
      "TutorSphere — دعوة عضوية خبير"
    ),
    subject: L(
      "{{InviterName}} vous invite à rejoindre le groupe {{GroupName}}",
      "{{InviterName}} invites you to join {{GroupName}}",
      "{{InviterName}} le invita a unirse a {{GroupName}}",
      "{{InviterName}} lädt Sie ein, {{GroupName}} beizutreten",
      "{{InviterName}} convida-o a juntar-se a {{GroupName}}",
      "{{InviterName}} 邀请您加入 {{GroupName}}",
      "{{InviterName}} يدعوك للانضمام إلى {{GroupName}}"
    ),
    title: L(
      "Invitation à rejoindre un groupe d'experts",
      "Invitation to join an expert group",
      "Invitación a unirse a un grupo de expertos",
      "Einladung zur Expertengruppe",
      "Convite para juntar-se a um grupo de especialistas",
      "加入专家组邀请",
      "دعوة للانضمام إلى مجموعة خبراء"
    ),
    hello: true,
    body: L(
      "<strong>{{InviterName}}</strong> vous invite à rejoindre le groupe d'experts <strong>{{GroupName}}</strong> sur TutorSphere.",
      "<strong>{{InviterName}}</strong> invites you to join the expert group <strong>{{GroupName}}</strong> on TutorSphere.",
      "<strong>{{InviterName}}</strong> le invita a unirse al grupo de expertos <strong>{{GroupName}}</strong> en TutorSphere.",
      "<strong>{{InviterName}}</strong> lädt Sie ein, der Expertengruppe <strong>{{GroupName}}</strong> auf TutorSphere beizutreten.",
      "<strong>{{InviterName}}</strong> convida-o a juntar-se ao grupo de especialistas <strong>{{GroupName}}</strong> no TutorSphere.",
      "<strong>{{InviterName}}</strong> 邀请您加入 TutorSphere 专家组 <strong>{{GroupName}}</strong>。",
      "<strong>{{InviterName}}</strong> يدعوك للانضمام إلى مجموعة الخبراء <strong>{{GroupName}}</strong> على TutorSphere."
    ),
    membershipLabels: {
      group: L("Groupe", "Group", "Grupo", "Gruppe", "Grupo", "小组", "المجموعة"),
      inviter: L("Invité par", "Invited by", "Invitado por", "Eingeladen von", "Convidado por", "邀请人", "بدعوة من")
    },
    note: L("{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}", "{{PersonalMessage}}"),
    body2: L(
      "Pour accepter ou refuser cette invitation, utilisez le bouton ci-dessous. Votre candidature pourra ensuite être soumise au vote des membres du groupe.",
      "To accept or decline this invitation, use the button below. Your application may then be submitted to a vote by group members.",
      "Para aceptar o rechazar esta invitación, use el botón de abajo. Su candidatura podrá luego someterse a votación de los miembros del grupo.",
      "Nutzen Sie die Schaltfläche unten, um die Einladung anzunehmen oder abzulehnen. Ihre Bewerbung kann anschließend von den Gruppenmitgliedern abgestimmt werden.",
      "Para aceitar ou recusar este convite, use o botão abaixo. A sua candidatura poderá depois ser submetida a votação pelos membros do grupo.",
      "请使用下方按钮接受或拒绝此邀请。您的申请随后可能提交给小组成员投票。",
      "لقبول هذه الدعوة أو رفضها، استخدم الزر أدناه. قد تُعرض ترشيحك بعد ذلك على تصويت أعضاء المجموعة."
    ),
    btn: L(
      "Voir mon invitation",
      "View my invitation",
      "Ver mi invitación",
      "Einladung ansehen",
      "Ver o meu convite",
      "查看我的邀请",
      "عرض دعوتي"
    ),
    btnUrl: "{{JoinUrl}}",
    text: L(
      "Bonjour {{FirstName}}, {{InviterName}} vous invite à rejoindre {{GroupName}}. {{PersonalMessage}} Lien : {{JoinUrl}}",
      "Hello {{FirstName}}, {{InviterName}} invites you to join {{GroupName}}. {{PersonalMessage}} Link: {{JoinUrl}}",
      "Hola {{FirstName}}, {{InviterName}} le invita a unirse a {{GroupName}}. {{PersonalMessage}} Enlace: {{JoinUrl}}",
      "Hallo {{FirstName}}, {{InviterName}} lädt Sie ein, {{GroupName}} beizutreten. {{PersonalMessage}} Link: {{JoinUrl}}",
      "Olá {{FirstName}}, {{InviterName}} convida-o a juntar-se a {{GroupName}}. {{PersonalMessage}} Link: {{JoinUrl}}",
      "{{FirstName}}，您好，{{InviterName}} 邀请您加入 {{GroupName}}。{{PersonalMessage}} 链接：{{JoinUrl}}",
      "مرحبًا {{FirstName}}، {{InviterName}} يدعوك للانضمام إلى {{GroupName}}. {{PersonalMessage}} الرابط: {{JoinUrl}}"
    )
  },
  {
    code: "EXPERT_MEMBERSHIP_VOTE_OPENED",
    name: L(
      "TutorSphere — Vote d'admission Expert",
      "TutorSphere — Expert admission vote",
      "TutorSphere — Voto de admisión experto",
      "TutorSphere — Expertenaufnahme-Abstimmung",
      "TutorSphere — Votação de admissão especialista",
      "TutorSphere — 专家入组投票",
      "TutorSphere — تصويت قبول خبير"
    ),
    subject: L(
      "Vote ouvert : candidature de {{CandidateName}} — {{GroupName}}",
      "Vote open: {{CandidateName}} application — {{GroupName}}",
      "Voto abierto: candidatura de {{CandidateName}} — {{GroupName}}",
      "Abstimmung offen: Bewerbung von {{CandidateName}} — {{GroupName}}",
      "Votação aberta: candidatura de {{CandidateName}} — {{GroupName}}",
      "投票已开启：{{CandidateName}} 的申请 — {{GroupName}}",
      "التصويت مفتوح: ترشيح {{CandidateName}} — {{GroupName}}"
    ),
    title: L(
      "Un vote d'admission est ouvert",
      "An admission vote is open",
      "Hay un voto de admisión abierto",
      "Eine Aufnahmeabstimmung ist geöffnet",
      "Uma votação de admissão está aberta",
      "入组投票已开启",
      "تصويت القبول مفتوح"
    ),
    hello: true,
    body: L(
      "La candidature de <strong>{{CandidateName}}</strong> pour rejoindre le groupe <strong>{{GroupName}}</strong> est ouverte au vote des membres.",
      "The application of <strong>{{CandidateName}}</strong> to join <strong>{{GroupName}}</strong> is open for member voting.",
      "La candidatura de <strong>{{CandidateName}}</strong> para unirse a <strong>{{GroupName}}</strong> está abierta a la votación de los miembros.",
      "Die Bewerbung von <strong>{{CandidateName}}</strong> für <strong>{{GroupName}}</strong> steht zur Abstimmung der Mitglieder.",
      "A candidatura de <strong>{{CandidateName}}</strong> para juntar-se a <strong>{{GroupName}}</strong> está aberta à votação dos membros.",
      "<strong>{{CandidateName}}</strong> 申请加入 <strong>{{GroupName}}</strong>，现已开放成员投票。",
      "ترشيح <strong>{{CandidateName}}</strong> للانضمام إلى <strong>{{GroupName}}</strong> مفتوح لتصويت الأعضاء."
    ),
    body2: L(
      "Merci de voter dès que possible. L'admission nécessite l'accord d'au moins 75&nbsp;% des autres membres actifs.",
      "Please vote as soon as possible. Admission requires approval from at least 75% of the other active members.",
      "Vote lo antes posible. La admisión requiere la aprobación de al menos el 75&nbsp;% de los demás miembros activos.",
      "Bitte stimmen Sie möglichst bald ab. Die Aufnahme erfordert die Zustimmung von mindestens 75&nbsp;% der anderen aktiven Mitglieder.",
      "Vote o mais cedo possível. A admissão exige a aprovação de pelo menos 75&nbsp;% dos outros membros ativos.",
      "请尽快投票。入组需获得至少 75% 其他活跃成员的同意。",
      "يُرجى التصويت في أقرب وقت. يتطلب القبول موافقة 75٪ على الأقل من الأعضاء النشطين الآخرين."
    ),
    btn: L(
      "Ouvrir les admissions",
      "Open admissions",
      "Abrir admisiones",
      "Aufnahmen öffnen",
      "Abrir admissões",
      "打开录取页",
      "فتح القبولات"
    ),
    btnUrl: "{{VoteUrl}}",
    text: L(
      "Bonjour {{FirstName}}, vote ouvert pour {{CandidateName}} ({{GroupName}}). Lien : {{VoteUrl}}",
      "Hello {{FirstName}}, vote open for {{CandidateName}} ({{GroupName}}). Link: {{VoteUrl}}",
      "Hola {{FirstName}}, voto abierto para {{CandidateName}} ({{GroupName}}). Enlace: {{VoteUrl}}",
      "Hallo {{FirstName}}, Abstimmung offen für {{CandidateName}} ({{GroupName}}). Link: {{VoteUrl}}",
      "Olá {{FirstName}}, votação aberta para {{CandidateName}} ({{GroupName}}). Link: {{VoteUrl}}",
      "{{FirstName}}，您好，{{CandidateName}}（{{GroupName}}）的投票已开启。链接：{{VoteUrl}}",
      "مرحبًا {{FirstName}}، التصويت مفتوح لـ {{CandidateName}} ({{GroupName}}). الرابط: {{VoteUrl}}"
    )
  },
  {
    code: "EXPERT_MEMBERSHIP_REJECTED",
    name: L(
      "TutorSphere — Candidature Expert non retenue",
      "TutorSphere — Expert application not retained",
      "TutorSphere — Candidatura de experto no retenida",
      "TutorSphere — Expertenbewerbung nicht angenommen",
      "TutorSphere — Candidatura de especialista não retida",
      "TutorSphere — 专家申请未通过",
      "TutorSphere — لم تُقبل ترشيح الخبير"
    ),
    subject: L(
      "Votre candidature Expert n'a pas été retenue — TutorSphere",
      "Your Expert application was not retained — TutorSphere",
      "Su candidatura de experto no fue retenida — TutorSphere",
      "Ihre Expertenbewerbung wurde nicht angenommen — TutorSphere",
      "A sua candidatura de especialista não foi retida — TutorSphere",
      "您的专家申请未获通过 — TutorSphere",
      "لم تُقبل ترشيحك كخبير — TutorSphere"
    ),
    title: L(
      "Candidature non retenue",
      "Application not retained",
      "Candidatura no retenida",
      "Bewerbung nicht angenommen",
      "Candidatura não retida",
      "申请未通过",
      "لم تُقبل الترشيح"
    ),
    titleColor: "#dc2626",
    hello: true,
    body: L(
      "Après examen, votre candidature pour rejoindre un groupe d'experts TutorSphere n'a pas été retenue.",
      "After review, your application to join a TutorSphere expert group was not retained.",
      "Tras la revisión, su candidatura para unirse a un grupo de expertos TutorSphere no fue retenida.",
      "Nach Prüfung wurde Ihre Bewerbung für eine TutorSphere-Expertengruppe nicht angenommen.",
      "Após análise, a sua candidatura para juntar-se a um grupo de especialistas TutorSphere não foi retida.",
      "经审核，您加入 TutorSphere 专家组的申请未获通过。",
      "بعد المراجعة، لم تُقبل ترشيحك للانضمام إلى مجموعة خبراء TutorSphere."
    ),
    reasonLabel: L("Motif", "Reason", "Motivo", "Grund", "Motivo", "原因", "السبب"),
    text: L(
      "Bonjour {{FirstName}}, votre candidature Expert n'a pas été retenue. Motif : {{Reason}}",
      "Hello {{FirstName}}, your Expert application was not retained. Reason: {{Reason}}",
      "Hola {{FirstName}}, su candidatura de experto no fue retenida. Motivo: {{Reason}}",
      "Hallo {{FirstName}}, Ihre Expertenbewerbung wurde nicht angenommen. Grund: {{Reason}}",
      "Olá {{FirstName}}, a sua candidatura de especialista não foi retida. Motivo: {{Reason}}",
      "{{FirstName}}，您好，您的专家申请未获通过。原因：{{Reason}}",
      "مرحبًا {{FirstName}}، لم تُقبل ترشيحك كخبير. السبب: {{Reason}}"
    )
  }
];

const hello = L("Bonjour {{FirstName}},", "Hello {{FirstName}},", "Hola {{FirstName}},", "Hallo {{FirstName}},", "Olá {{FirstName}},", "{{FirstName}}，您好，", "مرحبًا {{FirstName}}،");
const helloParent = L("Bonjour {{ParentFirstName}},", "Hello {{ParentFirstName}},", "Hola {{ParentFirstName}},", "Hallo {{ParentFirstName}},", "Olá {{ParentFirstName}},", "{{ParentFirstName}}，您好，", "مرحبًا {{ParentFirstName}}،");
const helloOwner = L("Bonjour {{OwnerFirstName}},", "Hello {{OwnerFirstName}},", "Hola {{OwnerFirstName}},", "Hallo {{OwnerFirstName}},", "Olá {{OwnerFirstName}},", "{{OwnerFirstName}}，您好，", "مرحبًا {{OwnerFirstName}}،");
const helloRecipient = L("Bonjour {{RecipientName}},", "Hello {{RecipientName}},", "Hola {{RecipientName}},", "Hallo {{RecipientName}},", "Olá {{RecipientName}},", "{{RecipientName}}，您好，", "مرحبًا {{RecipientName}}،");
const helloParentName = L("Bonjour {{ParentName}},", "Hello {{ParentName}},", "Hola {{ParentName}},", "Hallo {{ParentName}},", "Olá {{ParentName}},", "{{ParentName}}，您好，", "مرحبًا {{ParentName}}،");
const helloTutor = L("Bonjour {{TutorName}},", "Hello {{TutorName}},", "Hola {{TutorName}},", "Hallo {{TutorName}},", "Olá {{TutorName}},", "{{TutorName}}，您好，", "مرحبًا {{TutorName}}،");
const helloExpert = L("Bonjour {{ExpertFirstName}},", "Hello {{ExpertFirstName}},", "Hola {{ExpertFirstName}},", "Hallo {{ExpertFirstName}},", "Olá {{ExpertFirstName}},", "{{ExpertFirstName}}，您好，", "مرحبًا {{ExpertFirstName}}،");

function esc(s) {
  return s.replace(/\\/g, "\\\\").replace(/"/g, '\\"');
}

function btn(url, label) {
  return `<p style="text-align:center;margin:28px 0;"><a href="${url}" style="background:#5831E0;color:#ffffff;padding:12px 28px;text-decoration:none;border-radius:6px;font-weight:600;font-size:15px;">${label}</a></p>`;
}

function buildHtml(tpl, lang) {
  const color = tpl.titleColor || "#5831E0";
  const parts = [];
  parts.push(`<h1 style="color:${color};margin:0 0 12px;font-size:24px;">${t(tpl.title, lang)}</h1>`.replace("h1", tpl.code === "WELCOME" ? "h1" : "h2").replace("font-size:24px;", tpl.code === "WELCOME" ? "font-size:24px;" : ""));
  // fix: use h2 for non-welcome
  parts[0] = tpl.code === "WELCOME"
    ? `<h1 style="color:${color};margin:0 0 12px;font-size:24px;">${t(tpl.title, lang)}</h1>`
    : `<h2 style="color:${color};margin:0 0 12px;">${t(tpl.title, lang)}</h2>`;

  if (tpl.hello) parts.push(`<p>${t(hello, lang)}</p>`);
  if (tpl.helloParent) parts.push(`<p>${t(helloParent, lang)}</p>`);
  if (tpl.helloOwner) parts.push(`<p>${t(helloOwner, lang)}</p>`);
  if (tpl.helloRecipient) parts.push(`<p>${t(helloRecipient, lang)}</p>`);
  if (tpl.helloParentName) parts.push(`<p>${t(helloParentName, lang)}</p>`);
  if (tpl.helloTutor) parts.push(`<p>${t(helloTutor, lang)}</p>`);
  if (tpl.helloExpert) parts.push(`<p>${t(helloExpert, lang)}</p>`);
  if (tpl.body) parts.push(`<p>${t(tpl.body, lang)}</p>`);
  if (tpl.expertLabels) {
    const bg = tpl.tableBg || "#f5f3ff";
    parts.push(`<table style="width:100%;border-collapse:collapse;margin:16px 0;background:${bg};border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.expertLabels.school, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.expertLabels.country, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{Country}}</td></tr>
                </table>`);
  }
  if (tpl.inviteLabels) {
    const bg = tpl.tableBg || "#f5f3ff";
    const loginRow = tpl.inviteLabels.loginUrl
      ? `<tr><td style="padding:10px 14px;color:#555;">${t(tpl.inviteLabels.loginUrl, lang)}</td><td style="padding:10px 14px;font-weight:600;word-break:break-all;"><a href="{{LoginUrl}}" style="color:#5831E0;">{{LoginUrl}}</a></td></tr>`
      : "";
    parts.push(`<table style="width:100%;border-collapse:collapse;margin:16px 0;background:${bg};border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.inviteLabels.group, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.inviteLabels.email, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.inviteLabels.password, lang)}</td><td style="padding:10px 14px;font-weight:600;font-family:monospace;letter-spacing:0.02em;">{{TemporaryPassword}}</td></tr>
                  ${loginRow}
                </table>`);
  }
  if (tpl.addedLabels) {
    const bg = tpl.tableBg || "#f5f3ff";
    parts.push(`<table style="width:100%;border-collapse:collapse;margin:16px 0;background:${bg};border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.addedLabels.group, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.addedLabels.email, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{Email}}</td></tr>
                </table>`);
  }
  if (tpl.membershipLabels) {
    const bg = tpl.tableBg || "#f5f3ff";
    parts.push(`<table style="width:100%;border-collapse:collapse;margin:16px 0;background:${bg};border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.membershipLabels.group, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.membershipLabels.inviter, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{InviterName}}</td></tr>
                </table>`);
  }
  if (tpl.decisionLabels) {
    const bg = tpl.tableBg || "#f5f3ff";
    parts.push(`<table style="width:100%;border-collapse:collapse;margin:16px 0;background:${bg};border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.decisionLabels.school, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{SchoolName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.decisionLabels.group, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{GroupName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.decisionLabels.notes, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{Notes}}</td></tr>
                </table>`);
  }
  if (tpl.note) {
    parts.push(`<p style="background:#f5f3ff;border-left:4px solid #5831E0;padding:12px 16px;border-radius:4px;font-size:14px;color:#444;">${t(tpl.note, lang)}</p>`);
  }
  if (tpl.body2) parts.push(`<p>${t(tpl.body2, lang)}</p>`);
  if (tpl.reasonLabel) {
    parts.push(`<p><strong>${t(tpl.reasonLabel, lang)} :</strong> {{Reason}}</p>`);
  }
  if (tpl.statusNote) {
    parts.push(`<p>{{StatusNote}}</p>`);
  }
  if (tpl.labels) {
    const bg = tpl.tableBg || "#f5f3ff";
    parts.push(`<table style="width:100%;border-collapse:collapse;margin:16px 0;background:${bg};border-radius:6px;">
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.labels.subject, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{Subject}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.labels.tutor, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{TutorName}}</td></tr>
                  <tr><td style="padding:10px 14px;color:#555;">${t(tpl.labels.date, lang)}</td><td style="padding:10px 14px;font-weight:600;">{{LessonDate}}</td></tr>
                </table>`);
  }
  if (tpl.amountLabel && tpl.studentLabel) {
    parts.push(`<table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">${t(tpl.studentLabel, lang)}</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{StudentName}}</td></tr>
                  <tr><td style="padding:8px 0;color:#555;">${t(tpl.amountLabel, lang)}</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>`);
  } else if (tpl.amountLabel) {
    parts.push(`<table style="width:100%;border-collapse:collapse;margin:16px 0;">
                  <tr><td style="padding:8px 0;color:#555;">${t(tpl.amountLabel, lang)}</td><td style="padding:8px 0;font-weight:600;text-align:right;">{{Amount}}</td></tr>
                </table>`);
  }
  if (tpl.btn) parts.push(btn(tpl.btnUrl, t(tpl.btn, lang)));
  if (tpl.code === "EXPERT_INVITE") {
    parts.push(`<p style="margin:20px 0 0;padding:14px 16px;background:#f5f3ff;border:1px solid #ede9fb;border-radius:8px;font-size:14px;color:#333;">
                  <strong style="display:block;margin-bottom:6px;color:#5831E0;">${t(tpl.inviteLabels.loginUrl, lang)}</strong>
                  <a href="{{LoginUrl}}" style="color:#5831E0;font-weight:600;word-break:break-all;">{{LoginUrl}}</a>
                </p>`);
  }
  if (tpl.footerNote) parts.push(`<p style="font-size:13px;color:#888;">${t(tpl.footerNote, lang)}</p>`);
  return parts.join("\n                ");
}

function wrap(bodyHtml, footerHtml, seedRevision) {
  return `<div style="font-family:'Helvetica Neue',Arial,sans-serif;background:#f5f3ff;padding:32px 16px;min-height:100vh;">
          <div style="max-width:600px;margin:0 auto;background:#ffffff;border-radius:8px;overflow:hidden;box-shadow:0 2px 16px rgba(88,49,224,0.08);">
            <div style="background:#5831E0;padding:20px 24px;border-radius:8px 8px 0 0;">
          <p style="margin:0;font-size:20px;font-weight:bold;color:#ffffff;letter-spacing:-0.5px;">TutorSphere</p>
        </div>
            <div style="padding:32px 32px 24px;">
              ${bodyHtml}
              <hr style="border:none;border-top:1px solid #ede9fb;margin:32px 0 16px;" />
        <p style="font-size:12px;color:#888;margin:0;">
          ${footerHtml}
        </p>
            </div>
          </div>
        </div>
        <!-- tutorsphere-seed:${seedRevision} -->`;
}

let seeds = [];
for (const lang of LANGS) {
  for (const tpl of templates) {
    const html = wrap(buildHtml(tpl, lang), t(tpl.footer || footer, lang), REV);
    const name = esc(t(tpl.name, lang));
    const subject = esc(t(tpl.subject, lang));
    const text = esc(t(tpl.text, lang));
    // Use raw string literals carefully - embed as verbatim via @"..." equivalent in C# is """
    seeds.push({ code: tpl.code, lang, name: t(tpl.name, lang), subject: t(tpl.subject, lang), html, text: t(tpl.text, lang) });
  }
}

function toCsString(s) {
  // Prefer raw string literals """ ... """
  if (s.includes('"""')) throw new Error('triple quote in content');
  return `"""\n${s}\n"""`;
}

const items = seeds.map((s, i) => {
  const comma = i < seeds.length - 1 ? "," : "";
  return `        new(
            TemplateCode: "${s.code}",
            Name: ${JSON.stringify(s.name)},
            SubjectTemplate: ${JSON.stringify(s.subject)},
            HtmlBody: ${toCsString(s.html)},
            TextBody: ${JSON.stringify(s.text)},
            Language: "${s.lang}",
            SeedRevision: ${REV})${comma}`;
}).join("\n\n");

const file = `namespace SecureMailGateway.Data;

/// <summary>
/// Templates e-mail TutorSphere (fr, en, es, de, pt, zh-Hans, ar).
/// Généré par tools/generate-tutorsphere-templates.mjs — ne pas éditer à la main.
/// Client code : TUTORSPHERE.
/// </summary>
public static class TutorSphereTemplates
{
    public static IReadOnlyList<EmailTemplateSeed> Definitions { get; } =
    [
${items}
    ];
}
`;

fs.writeFileSync(outPath, file, "utf8");
console.log(`Wrote ${seeds.length} templates → ${outPath}`);