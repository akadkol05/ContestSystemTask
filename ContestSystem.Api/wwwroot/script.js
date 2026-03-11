const API = "https://localhost:44344/api";
let currentContestId = null;

async function api(path, method = 'GET', body = null) {
    const token = localStorage.getItem('token');
    const headers = { 'Content-Type': 'application/json' };
    if (token) headers['Authorization'] = `Bearer ${token}`;

    const res = await fetch(`${API}${path}`, { method, headers, body: body ? JSON.stringify(body) : null });
    if (res.status === 429) { alert("Rate limit hit! Wait 60s."); return null; }
    return res.ok ? res.json() : null;
}

function id(name) { return document.getElementById(name); }

async function handleAuth(mode) {
    const path = mode === 'login' ? '/Auth/login' : '/Auth/register';
    const body = mode === 'login'
        ? { username: id('l-user').value, password: id('l-pass').value }
        : { username: id('r-user').value, email: id('r-email').value, password: id('r-pass').value, role: "1" };

    const data = await api(path, 'POST', body);
    if (data) {
        if (mode === 'login') {
            localStorage.setItem('token', data.token);
            localStorage.setItem('role', String(data.role));
            localStorage.setItem('user', body.username);
            location.reload();
        } else { alert("Registered!"); toggleAuth(false); }
    }
}

async function loadContests() {
    const contests = await api('/Contest');
    const role = localStorage.getItem('role');
    const token = localStorage.getItem('token');

    // 1. Fetch participation history to see what's already done
    let history = [];
    if (token) {
        history = await api('/Contest/my-history') || [];
    }
    const participatedNames = history.map(h => h.contestName);

    if (!contests) return;

    id('contest-grid').innerHTML = contests.map(c => {
        // 2. Admin Check: Match the Role "3" from your C# Authorize attribute
        const isAdmin = (role === "3");
        const isDone = participatedNames.includes(c.name);

        return `
        <div class="col-md-4">
            <div class="card p-3 h-100 ${isAdmin ? 'admin-only' : ''}">
                <div class="d-flex justify-content-between align-items-center mb-2">
                    <h6 class="fw-bold m-0">${c.name}</h6>
                    ${isAdmin ? `<i class="fas fa-trash-alt delete-btn" onclick="deleteContest(${c.id})"></i>` : ''}
                </div>
                <p class="small text-muted mb-3">${c.accessLevel} | ${c.description || 'Join now'}</p>
                
                ${!token
                ? `<button disabled class="btn btn-sm btn-outline-secondary w-100">Login to Join</button>`
                : isDone
                    ? `<button class="btn btn-sm btn-secondary w-100" disabled><i class="fas fa-check me-1"></i> Already Submitted</button>`
                    : `<button onclick="enterContest(${c.id}, '${c.name}')" class="btn btn-sm btn-indigo w-100">Enter Contest</button>`
            }
            </div>
        </div>`;
    }).join('');
}
async function enterContest(contestId, name) {
    currentContestId = contestId;
    const contests = await api('/Contest');
    const contest = contests.find(c => c.id === contestId);

    if (!contest || !contest.questions) return alert("No questions available.");

    id('qTitle').innerText = name;
    id('qList').innerHTML = contest.questions.map((q, i) => `
        <div class="mb-4 question-block" data-qid="${q.id}">
            <p class="fw-bold mb-2">${i + 1}. ${q.text}</p>
            ${q.options.map(opt => `
                <div class="form-check">
                    <input class="form-check-input q-ans" type="radio" name="q${q.id}" value="${opt.id}" id="opt${opt.id}">
                    <label class="form-check-label" for="opt${opt.id}">${opt.text}</label>
                </div>
            `).join('')}
        </div>
    `).join('');

    new bootstrap.Modal(id('qModal')).show();
}

async function submitAnswers() {
    const answers = [];
    document.querySelectorAll('.question-block').forEach(block => {
        const qId = parseInt(block.dataset.qid);
        const selected = block.querySelector('.q-ans:checked');
        if (selected) {
            answers.push({ questionId: qId, selectedOptionIds: [parseInt(selected.value)] });
        }
    });

    const result = await api('/Contest/submit', 'POST', { contestId: currentContestId, answers });
    if (result) {
        alert(`Submitted! Score: ${result.score}`);
        location.reload();
    }
}

async function deleteContest(id) {
    if (confirm("Admin: Delete this contest?")) {
        await api(`/Contest/admin/delete-contest/${id}`, 'DELETE');
        location.reload();
    }
}

function toggleAuth(isReg) {
    id('login-box').classList.toggle('hidden', isReg);
}

async function loadDashboard() {
    const board = await api('/Contest/leaderboard');
    if (board) {
        id('leaderboard-data').innerHTML = board.map(u => `
            <div class="d-flex justify-content-between py-2 border-bottom">
                <span>${u.username}</span><b>${u.totalScore} pts</b>
            </div>
        `).join('');
    }

    const history = await api('/Contest/my-history');
    if (history) {
        id('history-data').innerHTML = history.map(h => `
            <tr>
                <td>${h.contestName}</td>
                <td>${h.scoreObtained}</td>
                <td><span class="badge bg-success">${h.prize}</span></td>
            </tr>
        `).join('');
    }
}

const token = localStorage.getItem('token');
if (token) {
    id('auth-section').classList.add('hidden');
    id('dashboard').classList.remove('hidden');
    id('nav-user').innerHTML = `Hi, <b>${localStorage.getItem('user')}</b> <button class="btn btn-sm ms-3 btn-outline-danger" onclick="localStorage.clear();location.reload()">Logout</button>`;
    loadDashboard();
}
loadContests();